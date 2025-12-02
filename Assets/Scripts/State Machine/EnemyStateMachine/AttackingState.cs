using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : EnemyState
{
    public bool attacking = false;
    public GameObject weapon;
    private CapsuleCollider weaponCollider;

    private void Start() {
        weaponCollider = weapon.GetComponent<CapsuleCollider>();
    }

    public override void Awake() {
        base.Awake();
        AddTransition<IdleState>(() => enemyController.GetDistanceBetweenEnemyAndPlayer() >= enemyController.GetEnemyStats().attackRange && !attacking);
        AddTransition<ChasingState>(() => attacking == false);
    }

    public override void OnEnable() { 
        base.OnEnable();
        attacking = true;
        StartCoroutine(Attacking());
    }

    public override void OnDisable() {
        base.OnDisable();
    }
    
    public override void Update() { 
        base.Update();
    }

    IEnumerator Attacking() {
        while (enemyController.GetDistanceBetweenEnemyAndPlayer() <= enemyController.GetEnemyStats().attackRange) {
            
            yield return new WaitForSeconds(1); // Attack start-up

            StartAttack();

            yield return new WaitForSeconds(1); // Attack cool-down
            
            EndAttack();
        }
    }

    private void StartAttack() 
    {
        weapon.GetComponent<CapsuleCollider>().enabled = true;
    }

    private void EndAttack() 
    {
        attacking = false;
        weapon.GetComponent<CapsuleCollider>().enabled = false;
    }
}
