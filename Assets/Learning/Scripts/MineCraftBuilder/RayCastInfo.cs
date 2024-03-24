using System;
using UnityEngine;

public class RayCastInfo : MonoBehaviour
{
    [SerializeField] private GameObject _sphere;
    [SerializeField] private Transform _camera;
    private Ray _ray;
    private RaycastHit _hit;

    public event Action<Vector3> PointClicked;

    private void Awake()
    {
        _sphere.SetActive(true);
    }

    private void FixedUpdate()
    {
        Physics.Raycast(_ray, out _hit, 50f);
    }

    private void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);        

        //Debug.DrawRay(_camera.position, _ray.direction * 50f, Color.red);
        Debug.DrawLine(_ray.origin, _hit.point, Color.green);
        _sphere.transform.position = _hit.point;

        if (Input.GetMouseButtonDown(0))
        {
            PointClicked?.Invoke(_hit.point);
        }
    }
}
