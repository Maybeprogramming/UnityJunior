using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputController : MonoBehaviour
{
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Shoot.performed += OnShooted;
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

    //������� ��� ������ SendMessage � BroadcastMessage
    //public void OnShoot()
    //{
    //    Debug.Log("OnShoot");
    //}


    //������� ��� ������ InvokeUnityEvents
    public void OnShoot(InputAction.CallbackContext context)
    {
        Debug.Log("OnShoot");
    }
}
