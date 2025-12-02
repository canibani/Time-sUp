using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindState : TimeObjectState
{
    public override void Awake() {
        base.Awake();
        AddTransition<NormalState>(() => timeObjectController.objectRecording.Count == 0);
        AddTransition<ObjectSelectionModeState>(() => timeObjectController.selectionMode == true);
    }

    public override void Update()
    {
        base.Update();
        timeObjectController.Rewind();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        timeObjectController.lastStateEnum = TimeOptionsEnum.REWIND;

    }

    public override void OnDisable() 
    {
        base.OnDisable();
    }
}
