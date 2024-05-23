using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(L3_PlayerStateMachine))]
public class L3_PlayerExample : MonoBehaviour
{
    [SerializeField] private L3_PlayerStateMachine _playerStateMachine;

    private void Awake()
    {
        _playerStateMachine = GetComponent<L3_PlayerStateMachine>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _playerStateMachine.TransitionToState(PlayerState.Walk);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _playerStateMachine.TransitionToState(PlayerState.Run);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _playerStateMachine.TransitionToState(PlayerState.Attack);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _playerStateMachine.TransitionToState(PlayerState.Idle);
        }
    }
}