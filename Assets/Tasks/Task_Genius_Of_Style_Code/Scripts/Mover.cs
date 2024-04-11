using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _waypointsConteiner;

    private Transform[] _waypoints;
    private int _currentWaypointIndex;

    private void Start()
    {
        _currentWaypointIndex = 0;
        _waypoints = new Transform[_waypointsConteiner.childCount];

        for (int i = 0; i < _waypoints.Length; i++)
        {
            _waypoints[i] = _waypointsConteiner.GetChild(i);
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position == _waypoints[_currentWaypointIndex].position)
        {
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;
        }

        Transform nextWaypoint = _waypoints[_currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, nextWaypoint.position, _speed * Time.deltaTime);
    }
}