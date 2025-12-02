using UnityEngine;

public class IdleState : EnemyState
{
    public override void Awake() {
        base.Awake();
        AddTransition<ChasingState>(() => enemyController.GetDistanceBetweenEnemyAndPlayer() <= enemyController.GetEnemyStats().maxChasingDistance);
    }

    public override void OnEnable() { 
        base.OnEnable();
    }

    public override void OnDisable() {
        base.OnDisable();
    }
    
    public override void Update() { 
        base.Update();
    }
}
