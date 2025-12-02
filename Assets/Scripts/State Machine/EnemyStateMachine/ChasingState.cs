using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : EnemyState
{
    public override void Awake() {
        base.Awake();
        AddTransition<IdleState>(() => enemyController.GetDistanceBetweenEnemyAndPlayer() >= enemyController.GetEnemyStats().maxChasingDistance);
        AddTransition<AttackingState>(() => enemyController.GetDistanceBetweenEnemyAndPlayer() <= enemyController.GetEnemyStats().attackRange);
    }

    public override void OnEnable() { 
        base.OnEnable();
    }

    public override void OnDisable() {
        base.OnDisable();
    }
    
    public override void Update() { 
        base.Update();
        enemyController.Chase();
    }
}
