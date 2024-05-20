using L2_FSM;
using UnityEngine;

public class ExampleFSM : MonoBehaviour
{
    [SerializeField] private FSM _fsm;
    [SerializeField] private float _walkSpeed = 1f;
    [SerializeField] private float _runSpeed = 2f;

    private void Start()
    {
        _fsm = new FSM();
        _fsm.AddState(new FsmStateIdle(_fsm));
        _fsm.AddState(new FsmStateRun(_fsm, transform, _runSpeed));
        _fsm.AddState(new FsmStateWalk(_fsm, transform, _walkSpeed));

        _fsm.SetState<FsmStateIdle>();
    }

    private void Update()
    {
        _fsm.Update();
    }
}