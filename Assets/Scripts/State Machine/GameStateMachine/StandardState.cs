using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardState : GameState
{
    public GameObject standardUI;

    public override void Awake() {
        base.Awake();
        AddTransition<SelectionModeState>(() => gameController.selectionMode);
    }

    public override void OnEnable() { 
        standardUI.SetActive(true);
        gameController.ResumeGame();
    }

    public override void OnDisable() {
        standardUI.SetActive(false);
        gameController.PauseGame();
    }
}
