using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _player;
    [SerializeField] private float _lengthRay;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;

    void Start()
    {
        _offset = transform.position - _player.position;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = _player.position + _offset;
        transform.RotateAround(_player.position, Vector3.up, _speed);
        transform.LookAt(_target.position);

        _offset = transform.position - _player.position;

        Debug.DrawRay(transform.position, transform.forward * _lengthRay, Color.red);
    }
}
