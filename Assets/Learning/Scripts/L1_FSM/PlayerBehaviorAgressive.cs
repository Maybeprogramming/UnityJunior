using UnityEngine;

namespace L1_FSM
{
    public class PlayerBehaviorAgressive : IPlayerBehavior
    {
        public void Enter()
        {
            Debug.Log("Enter Agressive Behavior");
        }

        public void Exit()
        {
            Debug.Log("Exit Agressive Behavior");
        }

        public void Update()
        {
            Debug.Log("Update Agressive Behavior");
        }
    }
}
