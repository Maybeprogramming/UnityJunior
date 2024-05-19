using UnityEngine;

namespace L1_FSM
{
    public class PlayerBehaviorActive : IPlayerBehavior
    {
        public void Enter()
        {
            Debug.Log("Enter Active Behavior");
        }

        public void Exit()
        {
            Debug.Log("Exit Active Behavior");
        }

        public void Update()
        {
            Debug.Log("Update Active Behavior");
        }
    }
}
