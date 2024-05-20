using L2_FSM;
using UnityEngine;

public class FsmStateMovement : FsmState
{
    protected readonly Transform Transform;
    protected readonly float Speed;

    public FsmStateMovement(FSM fsm, Transform transform, float speed) : base(fsm)
    {
        Transform = transform;
        Speed = speed;
    }

    public override void Enter()
    {
        Debug.Log($"Movement ({GetType().Name}) state Enter");
    }

    public override void Exit()
    {
        Debug.Log($"Movement ({GetType().Name}) state Exit");
    }

    public override void Update()
    {
        Debug.Log($"Movement ({GetType().Name}) state Update with Speed: {Speed}");

        var inputDirection = ReadInput();

        if (inputDirection.sqrMagnitude == 0f)
        {
            Fsm.SetState<FsmStateIdle>();
        }

        Move(inputDirection);
    }

    protected virtual void Move(Vector2 inputDirection)
    {
        Transform.position += new Vector3(inputDirection.x, 0f, inputDirection.y) * (Speed * Time.deltaTime);
    }

    protected Vector2 ReadInput()
    {
        var inputHorizontal = Input.GetAxis("Horizontal");
        var inputVertical = Input.GetAxis("Vertical");
        Vector2 inputDirection = new(inputHorizontal, inputVertical);

        return inputDirection.normalized;
    }
}