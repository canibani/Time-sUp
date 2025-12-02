using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForwardState : TimeObjectState
{
    public override void Awake() 
    {
        base.Awake();
        AddTransition<ObjectSelectionModeState>(() => timeObjectController.selectionMode == true);
    }

    public override void Update() {
        timeObjectController.Record();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        timeObjectController.lastStateEnum = TimeOptionsEnum.FAST_FORWARD;
    }

    public override void OnDisable() 
    {
        base.OnDisable();
    }
}
