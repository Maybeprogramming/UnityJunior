using System.Collections.Generic;
using UnityEngine;

public class PointerInstance : MonoBehaviour
{
    [SerializeField] private Pointer _pointer;
    [SerializeField] private List<Pointer> _pointers;
    [SerializeField] private RayCastInfo _hitPosition;

    private void SetPointPosition(Vector3 point)
    {
        Debug.Log(point);

        Pointer pointer = _pointer;
        _pointers.Add(pointer);
        Instantiate(pointer, point + Vector3.up, Quaternion.Euler(90f, 0f, 0f));
    }

    private void OnEnable()
    {
        _hitPosition.PointClicked += SetPointPosition;
    }

    private void OnDisable()
    {
        _hitPosition.PointClicked -= SetPointPosition;
    }
}