using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObjectState : State
{
    public TimeObjectController timeObjectController;

    public virtual void Awake() 
    { 
        base.Awake();
        timeObjectController = GetComponent<TimeObjectController>();
    }

    public override void OnEnable() { 
        Debug.Log(GetType());
    }

    public override void OnDisable() {
    }
    
    public override void Update() { }
}
