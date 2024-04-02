using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private float _speed;

    private Vector3 _target;

    private void Start()
    {
        _target = _spawner.Target;
    }

    private void OnEnable()
    {
        _spawner.Spawned += OnAddingEnemyToList;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= OnAddingEnemyToList;
    }

    private void OnAddingEnemyToList(GameObject enemy)
    {
        _enemies.Add(enemy);
    }

    private void Update()
    {
        Move();
        RemoveFinishingEnemies();
    }

    private void Move()
    {
        if (_enemies.Count == 0)
        {
            return;
        }

        foreach (var enemy in _enemies)
        {
            if (enemy.transform.position != _target)
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, _spawner.Target, Time.deltaTime * _speed);
                enemy.transform.LookAt(_target);
            }
        }
    }

    private void RemoveFinishingEnemies()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].transform.position == _target)
            {
                Destroy(_enemies[i]);
                _enemies.Remove(_enemies[i]);
            }
        }
    }
}
