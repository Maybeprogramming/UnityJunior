using System.Collections.Generic;
using UnityEngine;

public class PointerInstance : MonoBehaviour
{
    [SerializeField] private Pointer _pointer;
    [SerializeField] private RayCastInfo _hitPosition;

    private void SetPointPosition(Vector3 point)
    {
        Debug.Log(point);

        Instantiate(_pointer, point + Vector3.up, Quaternion.Euler(90f, 0f, 0f));
    }

    private void OnEnable()
    {
        _hitPosition.OnPointModifyClicked += SetPointPosition;
        _hitPosition.OnPointCliked += SetPointPosition;
    }

    private void OnDisable()
    {
        _hitPosition.OnPointModifyClicked -= SetPointPosition;
        _hitPosition.OnPointCliked -= SetPointPosition;
    }
}