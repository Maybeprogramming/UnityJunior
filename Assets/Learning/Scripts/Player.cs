using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _lookSpeed;
    [SerializeField] private ObjectPicker _objectPicker;

    private PlayerInput _playerInput;

    private Vector2 _lookDirection;
    private Vector2 _moveDirection;

    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerInput.Player.Pickup.performed += ctx => _objectPicker.PickUp();
        _playerInput.Player.Throw.performed += ctx => _objectPicker.Throw();
        _playerInput.Player.Drop.performed += ctx => _objectPicker.Drop();

        // Нужно в случае обработки значений инпута,
        // но нужны методы на отписку при отмене
        // или установление векторов в дополнительных обработчиках в 0 значение.
        //_playerInput.Player.Look.performed += OnLook;
        //_playerInput.Player.Move.performed += OnMove;
    }

    private void Update()
    {
        _lookDirection = _playerInput.Player.Look.ReadValue<Vector2>();
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();

        Move();
        Look();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Look()
    {
        if (_lookDirection.sqrMagnitude < 0.1f)
        {
            return;
        }

        float scaledLookSpeed = _lookSpeed * Time.deltaTime;
        Vector3 offset = new Vector3(-_lookDirection.y, _lookDirection.x, 0f) * scaledLookSpeed;

        transform.Rotate(offset);
    }

    private void Move()
    {
        if (_moveDirection.sqrMagnitude < 0.1f)
        {
            return;
        }

        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 offset = new Vector3(_moveDirection.x, 0f, _moveDirection.y) * scaledMoveSpeed;

        transform.Translate(offset);
    }
    
    //private void OnLook(InputAction.CallbackContext context)
    //{
    //    _lookDirection = context.action.ReadValue<Vector2>();
    //}

    //private void OnMove(InputAction.CallbackContext context)
    //{
    //    _moveDirection = context.action.ReadValue<Vector2>();
    //}
}
