using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptiveFollowerLerp : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _lengthRay;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _player.position, _speed * Time.deltaTime);
        transform.LookAt(_player.position);


        Debug.DrawRay(transform.position, transform.forward * _lengthRay, Color.green);
    }
}
