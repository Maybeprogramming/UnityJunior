using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;

    void Update()
    {
        transform.LookAt( _target, transform.up);
    }
}
