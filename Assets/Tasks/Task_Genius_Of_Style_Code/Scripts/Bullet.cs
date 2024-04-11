using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _speed;
    private Vector3 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
    }

    public void Init(float speed, Vector3 direction)
    {
        _speed = speed;
        _direction = direction;
        _rigidbody.transform.up = direction;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _direction * _speed;
    }
}
