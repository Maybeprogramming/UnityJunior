using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private List<Transform> _spawnpoints;
    [SerializeField] private GameObject _enemy;
    

    public event Action<GameObject> Spawned;

    private void OnEnable()
    {
        _timer.Tick += Spawn;
    }

    private void Spawn()
    {
        int positionIndex = new System.Random().Next(0, _spawnpoints.Count);
        GameObject newEnemy = Instantiate(_enemy, _spawnpoints[positionIndex].position, Quaternion.Euler(0f,90f,0f));
        Spawned?.Invoke(newEnemy);
    }

    private void OnDisable()
    {
        _timer.Tick -= Spawn;
    }
}
