using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private Vector3 _moveDirection;
    [SerializeField] private float _playerSpeed;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Shoot.performed += OnShoot;
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
        var bullet = Instantiate(_prefabBullet, transform.position + Vector3.forward * 2f, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = Vector3.forward * _bulletSpeed;

        Debug.Log("OnShoot");
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var vector2direction = _playerInput.Player.Move.ReadValue<Vector2>();
        _moveDirection = new Vector3(vector2direction.x, 0f, vector2direction.y);

        transform.Translate(_moveDirection * Time.deltaTime);
    }
}
