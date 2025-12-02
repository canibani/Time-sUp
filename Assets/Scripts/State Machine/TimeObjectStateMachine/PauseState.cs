using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : TimeObjectState
{
    public override void Awake() {
        base.Awake();
        AddTransition<ObjectSelectionModeState>(() => timeObjectController.selectionMode == true);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        timeObjectController.lastStateEnum = TimeOptionsEnum.PAUSE;
        timeObjectController.StoreObjectData();
        timeObjectController.Pause();
    }

    public override void OnDisable() 
    {
        base.OnDisable();
        timeObjectController.Resume();
    }

    private void FixedUpdate() {
        timeObjectController.Pause();
    }
}
