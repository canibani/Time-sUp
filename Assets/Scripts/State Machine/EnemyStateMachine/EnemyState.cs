using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : State
{
    public EnemyController enemyController;

    public override void Awake() {
        base.Awake();
        enemyController = transform.GetComponent<EnemyController>();
    }

    public override void OnEnable() { 
    }

    public override void OnDisable() {
    }
    
    public override void Update() { }
}
