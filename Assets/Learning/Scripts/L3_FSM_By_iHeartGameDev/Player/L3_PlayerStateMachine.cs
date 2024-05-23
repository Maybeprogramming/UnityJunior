using UnityEngine;

public class L3_PlayerStateMachine : L3_StateManager<PlayerState>
{
    private void Awake()
    {
        States.Add(PlayerState.Idle, new L3_PlayerIdleState(PlayerState.Idle));
        States.Add(PlayerState.Run, new L3_PlayerIdleState(PlayerState.Run));
        States.Add(PlayerState.Walk, new L3_PlayerIdleState(PlayerState.Walk));
        States.Add(PlayerState.Attack, new L3_PlayerIdleState(PlayerState.Attack));

        CurrentState = States[PlayerState.Idle];
    }

    private void Update()
    {
        CurrentState.Update();
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