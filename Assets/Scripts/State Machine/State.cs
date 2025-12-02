using System;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public List<(Func<bool>, State)> transitions;

    public virtual void Awake() 
    { 
        transitions = new List<(Func<bool>, State)>();
    }

    public virtual void OnEnable() { }

    public virtual void OnDisable() { }
    public virtual void Update() { }

    public void LateUpdate()
    {
        foreach ((Func<bool> condition, State target) in transitions)
        {
            if (condition())
            {
                target.enabled = true;
                this.enabled = false;
                return;
            }
        }
    }

    public void AddTransition<StateType>(Func<bool> condition) where StateType : State
    {
        var target = GetComponent<StateType>();
        transitions.Add((condition, target));
    }
}
