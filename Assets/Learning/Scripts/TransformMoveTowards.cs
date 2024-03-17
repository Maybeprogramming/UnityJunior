using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMoveTowards : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;


    void Update()
    {
        // Движение объекта к цели с заданной скоростью
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
    }
}
