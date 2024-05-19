using UnityEngine;

namespace L1_FSM
{
    public class TestInput: MonoBehaviour
    {
        private Player _player;

        private void Start()
        {
            _player = GetComponent<Player>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _player.SetBehaviorIdle();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _player.SetBehaviorActive();
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _player.SetBehaviorAgressive();
            }
        }
    }
}