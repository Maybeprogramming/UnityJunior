using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _waypoints;

    private Transform[] _allWaypoints;
    private int _currentWaypointIndex;

    private void Start()
    {
        _currentWaypointIndex = 0;
        _allWaypoints = new Transform[_waypoints.childCount];

        for (int i = 0; i < _waypoints.childCount; i++)
        {
            _allWaypoints[i] = _waypoints.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        var nextWaypoint = _allWaypoints[_currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, nextWaypoint.position, _speed * Time.deltaTime);

        if (transform.position == nextWaypoint.position)
        {
            nextWaypoint.position = GetNextWaypoint();
        }
    }

    private Vector3 GetNextWaypoint()
    {
        _currentWaypointIndex++;

        if (_currentWaypointIndex == _allWaypoints.Length)
        {
            _currentWaypointIndex = 0;
        }

        var nextWaypoint = _allWaypoints[_currentWaypointIndex].transform.position;
        transform.forward = nextWaypoint - transform.position;

        return nextWaypoint;
    }
}
