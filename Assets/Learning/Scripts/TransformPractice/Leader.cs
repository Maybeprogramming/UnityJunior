using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leader : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Transform _pointer;
    [SerializeField] private float _speed;
    [SerializeField] private float _lengthRay;

    private int _currentWaypoint = 0;

    private void Update()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;
        }

        _pointer.position = _waypoints[_currentWaypoint].position + new Vector3(0f, 0.5f, 0f);

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
        transform.LookAt(_waypoints[_currentWaypoint].position);

        Debug.DrawRay(transform.position, transform.forward * _lengthRay, Color.yellow);
    }
}
