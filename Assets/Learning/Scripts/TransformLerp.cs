using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformLerp : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;


    void Update()
    {
        // Движение объекта к цели с заданной скоростью
        transform.position = Vector3.Lerp(transform.position, _player.position, _speed * Time.deltaTime);
    }
}
