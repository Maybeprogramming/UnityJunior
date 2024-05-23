using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class L3_StateManager<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, L3_BaseState<EState>> States = new Dictionary<EState, L3_BaseState<EState>>();

    protected L3_BaseState<EState> CurrentState;

    protected bool IsTransitioningState = false;

    private void Start()
    {
        CurrentState.Enter();
    }

    private void Update()
    {
        EState nextState = CurrentState.GetNextState();

        if (IsTransitioningState == false && nextState.Equals(CurrentState.StateKey))
        {
            CurrentState.Update();
        }
        else if (IsTransitioningState == false)
        {
            TransitionToState(nextState);
        }
    }

    public void TransitionToState(EState stateKey)
    {
        IsTransitioningState = true;
        CurrentState.Exit();
        CurrentState = States[stateKey];
        CurrentState.Enter();
        IsTransitioningState = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        CurrentState.OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        CurrentState.OnTriggerExit(other);
    }

    private void OnTriggerStay(Collider other)
    {
        CurrentState.OnTriggerStay(other);
    }
}