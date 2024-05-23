using UnityEngine;

public class L3_PlayerIdleState : L3_BaseState<PlayerState>
{
    public L3_PlayerIdleState(PlayerState key) : base(key) { }

    public override void Enter()
    {
        Debug.Log($"Enter state: [{StateKey}]");
    }

    public override void Exit()
    {
        Debug.Log($"Exit state: [{StateKey}]");
    }

    public override PlayerState GetNextState()
    {
        return StateKey;
    }

    public override void OnTriggerEnter(Collider other)
    {
        Debug.Log($"��������� ������������ � ����������� {other.name} � ��������� {StateKey}");
    }

    public override void OnTriggerExit(Collider other)
    {
        Debug.Log($"��������� ����� �� ���������� {other.name} � ��������� {StateKey}");
    }

    public override void OnTriggerStay(Collider other)
    {
        Debug.Log($"������� � ���������� {other.name} � ��������� {StateKey}");
    }

    public override void Update()
    {
        Debug.Log($"Update state: [{StateKey}]");
    }
}