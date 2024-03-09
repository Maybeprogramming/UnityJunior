using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRotatorAxisAround : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _angleY;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _center.GetLocalPositionAndRotation(out Vector3 localPosition, out Quaternion localRotation);
        transform.rotation = Quaternion.Euler(0f, _center.eulerAngles.y, 0f);
        _angleY = _center.eulerAngles.y;
    }
}
