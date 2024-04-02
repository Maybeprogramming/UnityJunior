using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private List<Transform> _spawnpoints;
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _enemy;    

    public event Action<GameObject> Spawned;

    public Vector3 Target => _target.position;

    private void Spawn()
    {
        int pointIndex = new System.Random().Next(0, _spawnpoints.Count);
        GameObject newEnemy = Instantiate(_enemy, _spawnpoints[pointIndex].position, Quaternion.identity);
        Spawned?.Invoke(newEnemy);
    }

    private void OnEnable()
    {
        _timer.Tick += Spawn;
    }

    private void OnDisable()
    {
        _timer.Tick -= Spawn;
    }
}
