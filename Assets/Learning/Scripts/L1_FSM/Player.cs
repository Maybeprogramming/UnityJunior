using System;
using System.Collections.Generic;
using UnityEngine;

namespace L1_FSM
{
    public class Player : MonoBehaviour
    {
        private Dictionary<Type, IPlayerBehavior> _behaviorsMap;
        private IPlayerBehavior _behaviorCurrent;

        private void Start()
        {
            InitBehaviors();
            SetBehaviorByDefault();
        }

        private void Update()
        {
            if (_behaviorCurrent != null)
            {
                _behaviorCurrent.Update();
            }
        }

        private void InitBehaviors()
        {
            _behaviorsMap = new Dictionary<Type, IPlayerBehavior>();

            _behaviorsMap[typeof(PlayerBehaviorActive)] = new PlayerBehaviorActive();
            _behaviorsMap[typeof(PlayerBehaviorAgressive)] = new PlayerBehaviorAgressive();
            _behaviorsMap[typeof(PlayerBehaviorIdle)] = new PlayerBehaviorIdle();
        }

        private void SetBehavior(IPlayerBehavior newBehavior)
        {
            if (_behaviorCurrent != null)
            {
                _behaviorCurrent.Exit();
            }

            _behaviorCurrent = newBehavior;
            _behaviorCurrent.Enter();
        }

        private void SetBehaviorByDefault()
        {
            //var behaviorByDefault = GetBehavior<PlayerBehaviorIdle>();
            //SetBehavior(behaviorByDefault);
            SetBehaviorIdle();
        }

        private T GetBehavior<T>() where T : IPlayerBehavior
        {
            var type = typeof(T);
            return (T)_behaviorsMap[type];
        }

        public void SetBehaviorIdle()
        {
            var behavior = GetBehavior<PlayerBehaviorIdle>();
            SetBehavior(behavior);
        }

        public void SetBehaviorAgressive()
        {
            var behavior = GetBehavior<PlayerBehaviorAgressive>();
            SetBehavior(behavior);
        }

        public void SetBehaviorActive()
        {
            var behavior = GetBehavior<PlayerBehaviorActive>();
            SetBehavior(behavior);
        }
    }
}