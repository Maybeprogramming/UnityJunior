using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Vector3 _moveDirection;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rigidbody;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput.Player.Shoot.performed += OnShoot;
        _playerInput.Player.Jump.performed += Jump;
        //_playerInput.Player.Look.performed += Look;
    }

    private void OnShooted(InputAction.CallbackContext context)
    {
        Debug.Log("OnShoot");
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    //Вариант для режима SendMessage и BroadcastMessage
    //public void OnShoot()
    //{
    //    Debug.Log("OnShoot");
    //}


    //Вариант для режима InvokeUnityEvents
    public void OnShoot(InputAction.CallbackContext context)
    {
        var bullet = Instantiate(_prefabBullet, transform.position + transform.forward * 2f, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * _bulletSpeed;

        Debug.Log("OnShoot");
    }

    private void Update()
    {
        Move();

        Look();
    }

    private void Move()
    {
        var vector2direction = _playerInput.Player.Move.ReadValue<Vector2>();
        //_moveDirection = new Vector3(vector2direction.x, 0f, vector2direction.y);
        _moveDirection = new Vector3(0f, 0f, vector2direction.y);

        transform.Translate(_moveDirection * Time.deltaTime * _playerSpeed);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        _rigidbody.AddForce(Vector3.up * _jumpPower);
    }

    private void Look()
    {
        float rotation = _playerInput.Player.Look.ReadValue<float>();

        transform.Rotate(rotation * Vector3.up * _rotateSpeed * Time.deltaTime);
    }    
    
    
    //private void Look(InputAction.CallbackContext context)
    //{
    //    float rotation = context.ReadValue<float>();

    //    transform.Rotate(rotation * Vector3.up * _rotateSpeed * Time.deltaTime);
    //}
}
