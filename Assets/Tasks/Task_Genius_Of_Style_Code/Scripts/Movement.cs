using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _waypoints;

    private Transform[] _AllWaypoints;
    private int _currentWaypointIndex;

    private void Start()
    {
        _currentWaypointIndex = 0;
        _AllWaypoints = new Transform[_waypoints.childCount];

        for (int i = 0; i < _waypoints.childCount; i++)
        {
            _AllWaypoints[i] = _waypoints.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        var nextWaypoint = _AllWaypoints[_currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, nextWaypoint.position, _speed * Time.deltaTime);

        if (transform.position == nextWaypoint.position)
        {
            nextWaypoint.position = GetNextWaypoint();
        }
    }

    private Vector3 GetNextWaypoint()
    {
        _currentWaypointIndex++;

        if (_currentWaypointIndex == _AllWaypoints.Length)
        {
            _currentWaypointIndex = 0;
        }

        var nextWaypoint = _AllWaypoints[_currentWaypointIndex].transform.position;
        transform.forward = nextWaypoint - transform.position;

        return nextWaypoint;
    }
}
