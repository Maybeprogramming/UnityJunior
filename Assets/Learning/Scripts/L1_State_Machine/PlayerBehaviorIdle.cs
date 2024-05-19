using UnityEngine;

namespace L1_FSM
{
    public class PlayerBehaviorIdle : IPlayerBehavior
    {
        public void Enter()
        {
            Debug.Log("Enter Idle Behavior");
        }

        public void Exit()
        {
            Debug.Log("Exit Idle Behavior");
        }

        public void Update()
        {
            Debug.Log("Update Idle Behavior");
        }
    }
}
