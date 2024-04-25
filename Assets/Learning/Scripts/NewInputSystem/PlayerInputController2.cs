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

    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveDirection = context.action.ReadValue<Vector2>();

        Debug.Log(moveDirection);
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
