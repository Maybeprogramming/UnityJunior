using L2_FSM;
using UnityEngine;

public class FsmStateRun : FsmStateMovement
{
    public FsmStateRun(FSM fsm, Transform transform, float speed) : base(fsm, transform, speed)
    {
    }

    public override void Update()
    {
        Debug.Log($"Run state Update with Speed: {Speed}");

        var inputDirection = ReadInput();

        if (inputDirection.sqrMagnitude == 0f)
        {
            Fsm.SetState<FsmStateIdle>();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Fsm.SetState<FsmStateWalk>();
        }

        Move(inputDirection);
    }
}