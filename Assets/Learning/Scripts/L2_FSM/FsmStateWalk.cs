using L2_FSM;
using UnityEngine;

public class FsmStateWalk : FsmStateMovement
{
    public FsmStateWalk(FSM fsm, Transform transform, float speed) : base(fsm, transform, speed)
    {
    }

    public override void Update()
    {
        Debug.Log($"Walk state Update with Speed: {Speed}");

        var inputDirection = ReadInput();

        if (inputDirection.sqrMagnitude == 0f)
        {
            Fsm.SetState<FsmStateIdle>();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Fsm.SetState<FsmStateRun>();
        }

        Move(inputDirection);
    }
}