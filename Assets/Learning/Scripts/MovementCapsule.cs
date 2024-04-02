using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class MovementCapsule : MonoBehaviour
{
    [SerializeField] private List<Vector3> _waypoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _lengthRay;
    [SerializeField] private RayCastInfo _hitPosition;

    private int _currentWaypoint = 0;

    private void Update()
    {
        if (_waypoints.Count != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, _waypoints.First(), _speed * Time.deltaTime);
            transform.LookAt(_waypoints.First());
        }

        if (_waypoints.Count != 0 && (_waypoints[_currentWaypoint] - transform.position).magnitude <= 0.01f)
        {
            Debug.Log("Достигли точки");
            _waypoints.RemoveAt(_currentWaypoint);
        }


        Debug.DrawRay(transform.position, transform.forward * _lengthRay, Color.yellow);
    }

    private void SetPointPosition(Vector3 point)
    {
        _waypoints.Add(new Vector3(point.x, transform.position.y, point.z));
        Debug.Log(point);
        Debug.Log("Установка позиции кликом ЛКМ");
    }

    private void SetModifyPointPosition(Vector3 point)
    {
        _waypoints.Clear();
        _waypoints.Add(new Vector3(point.x, transform.position.y, point.z));
        Debug.Log(point);
        Debug.Log("Установка позиции с комбинацией CTRL + ЛКМ");
    }

    private void OnEnable()
    {
        _hitPosition.OnPointCliked += SetPointPosition;
        _hitPosition.OnPointModifyClicked += SetModifyPointPosition;
    }

    private void OnDisable()
    {
        _hitPosition.OnPointModifyClicked -= SetModifyPointPosition;
        _hitPosition.OnPointCliked -= SetPointPosition;
    }
}
