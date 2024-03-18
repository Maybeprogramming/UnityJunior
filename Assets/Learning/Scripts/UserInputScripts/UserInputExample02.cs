using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputExample02 : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _forceJump;

    private float _horizontal;
    private float _vertical;

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        if (_horizontal != 0)
        {
            transform.Rotate(Vector3.up * -_horizontal * Time.deltaTime * _rotationSpeed);
        }

        if (_vertical != 0)
        {
            transform.Translate(Vector3.forward * _vertical * Time.deltaTime * _moveSpeed);
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    transform.Translate((Vector3.forward + Vector3.up) * _forceJump * Time.deltaTime );
        //}
    }
}
