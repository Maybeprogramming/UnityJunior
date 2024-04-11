using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField, Range(1, 5000)] private float _moveSpeed;

    private float _speedDivider;
    void Start()
    {
        _speedDivider = 1000;
    }

    void Update()
    {
        transform.position = transform.position + (transform.forward * _moveSpeed / _speedDivider * Time.deltaTime);
    }
}