using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAttaker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _health;

    private InputControls _inputControls;
    private IDamageable _target;
    private float keyValue;

    public void Init(IDamageable target)
    {
        _target = target;
    }

    private void Awake()
    {
        _inputControls = new InputControls();
    }

    private void OnEnable()
    {
        _inputControls.Enable();
    }

    private void OnDisable()
    {
        _inputControls.Disable();
    }

    private void Start()
    {
        _inputControls.Player.Key_E.performed += OnTakeDamage;
        _inputControls.Player.Key_Q.performed += OnGiveHealth;
        _target.HealthChanged += OnPrintMessage;
    }

    private void Update()
    {
        //keyValue = _inputControls.Player.Key_Q.ReadValue<float>();
        //Debug.Log(keyValue);
    }

    private void OnGiveHealth(InputAction.CallbackContext context)
    {
        if (_inputControls.Player.Key_Q.IsPressed())
        {
            _target.GiveHealth(_health * 2);
        }
        else
        {
            _target.GiveHealth(_health);
        }
    }

    private void OnPrintMessage(int value)
    {
        Debug.Log(value);
    }

    private void OnTakeDamage(InputAction.CallbackContext context)
    {
        Debug.Log("Attacked");
        _target.TakeDamage(_damage);
    }
}
