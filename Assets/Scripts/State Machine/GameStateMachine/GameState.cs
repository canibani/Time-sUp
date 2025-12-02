using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : State
{
    public GameController gameController;

    public override void Awake() {
        base.Awake();
    }

    public override void OnEnable() { 
    }

    public override void OnDisable() {
    }
    
    public override void Update() { }
}
