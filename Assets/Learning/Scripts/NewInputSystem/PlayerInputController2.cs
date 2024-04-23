using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputController2 : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerInput.Player.Shoot.performed += OnShoot;
        _playerInput.Player.Move.performed += OnMove;
    }

    private void Update()
    {
        Debug.Log(_playerInput.Player.Move.ReadValue<Vector2>().x);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<Vector2>().x;

        Debug.Log(value);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        //Логика выстрела
        Debug.Log("Shoot");
    }
}
