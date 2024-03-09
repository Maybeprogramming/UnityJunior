using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinRotator : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationAxis;
    [SerializeField] private Transform _bladiesAxis;
    [SerializeField] private float _speed;

    void Update()
    {

    }

    private void FixedUpdate()
    {
        transform.RotateAround(_bladiesAxis.transform.position, _rotationAxis, _speed * Time.deltaTime);
    }
}
