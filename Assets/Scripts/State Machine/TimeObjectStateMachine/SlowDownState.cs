using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownState : TimeObjectState
{
    public override void Awake() {
        base.Awake();
        AddTransition<ObjectSelectionModeState>(() => timeObjectController.selectionMode == true);
    }

    public override void Update() {
        timeObjectController.Record();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        timeObjectController.lastStateEnum = TimeOptionsEnum.SLOW_DOWN;

    }

    public override void OnDisable() 
    {
        base.OnDisable();
    }
}
