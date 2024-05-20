using L2_FSM;
using UnityEngine;

public class FsmStateIdle : FsmState
{
    public FsmStateIdle(FSM fsm) : base(fsm)
    {
    }

    public override void Enter()
    {
        Debug.Log("Idle state Enter");
    }

    public override void Exit()
    {
        Debug.Log("Idle state Exit");
    }

    public override void Update()
    {
        Debug.Log("Idle state Update");

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Fsm.SetState<FsmStateWalk>();
        }
    }
}