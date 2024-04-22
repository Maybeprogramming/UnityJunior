using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerInputController2 : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }

    void Jump()
    {
        _rigidbody.velocity = Vector3.up * _jumpPower * _jumpCurve.Evaluate(Time.time);
    }
}
