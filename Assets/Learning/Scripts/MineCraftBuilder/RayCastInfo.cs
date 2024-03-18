using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class RayCastInfo : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _hitPointSphere;
    [SerializeField] private Pointer _pointer;
    [SerializeField] private List<Pointer> _pointers;
    private Ray _ray;
    private RaycastHit _hit;

    private void FixedUpdate()
    {
        Physics.Raycast(_ray, out _hit, 50f);
    }

    void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _hitPointSphere.position = _hit.point;

        Debug.DrawRay(_camera.position, _ray.direction * 50f, Color.red);
        Debug.DrawLine(_ray.origin, _hit.point, Color.green);

        if (Input.GetMouseButtonDown(0))
        {
            Pointer pointer = _pointer;
            _pointers.Add(pointer);
            Instantiate(pointer, _hit.point + Vector3.up, Quaternion.Euler(90f, 0f, 0f));
        }
    }
}