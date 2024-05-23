using System;
using UnityEngine;

public abstract class L3_BaseState<EState> where EState : Enum
{
    public L3_BaseState(EState key)
    {
        StateKey = key;
    }

    public EState StateKey { get; private set; }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
    public abstract EState GetNextState();
    public abstract void OnTriggerEnter(Collider other);
    public abstract void OnTriggerExit(Collider other);
    public abstract void OnTriggerStay(Collider other);
}
