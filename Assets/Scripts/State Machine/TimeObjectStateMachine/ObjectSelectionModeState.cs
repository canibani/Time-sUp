using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectionModeState : TimeObjectState
{
    public GameObject selectionModeSelector;
    private OptionSelector optionSelectorScript;
    public TimeOptionsEnum? newOption;
    // public bool selected;

    public override void Awake() {
        base.Awake();
        AddTransition<RewindState>(() => newOption == TimeOptionsEnum.REWIND && !timeObjectController.selectionMode);
        AddTransition<PauseState>(() => newOption == TimeOptionsEnum.PAUSE && !timeObjectController.selectionMode);
        AddTransition<NormalState>(() => newOption == TimeOptionsEnum.NORMAL && !timeObjectController.selectionMode);
        AddTransition<SlowDownState>(() => newOption == TimeOptionsEnum.SLOW_DOWN && !timeObjectController.selectionMode);
        AddTransition<FastForwardState>(() => newOption == TimeOptionsEnum.FAST_FORWARD && !timeObjectController.selectionMode);
    }

    private void Start() 
    {
        optionSelectorScript = selectionModeSelector.GetComponent<OptionSelector>();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        newOption = timeObjectController.lastStateEnum;
        Debug.Log(newOption);      
    }

    public override void OnDisable() 
    {
        base.OnDisable();
        Untarget();
    }

    private void Target() 
    {
        timeObjectController.renderer.material.color = Color.red;
    }

    private void Untarget() 
    {
        timeObjectController.renderer.material.color = Color.white;
    }

    public void SetTimeOption() 
    {
        newOption = optionSelectorScript.GetOption();
        timeObjectController.renderer.material.color = Color.green;
    }

    void OnMouseOver()
    {
        if (enabled) 
        {
            Target();
        } 
    }

    private void OnMouseExit() {
        Untarget();
    }

    private void OnMouseDown() 
    {
        if (enabled) 
        {
            SetTimeOption();
        } 
    }
}