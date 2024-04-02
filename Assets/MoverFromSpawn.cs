using System.Collections.Generic;
using UnityEngine;

public class MoverFromSpawn : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private float _speed;

    private void OnEnable()
    {
        _spawner.Spawned += OnMove;
    }

    private void OnDisable()
    {
        _spawner.Spawned -= OnMove;
    }

    private void OnMove(GameObject enemy)
    {
        _enemies.Add(enemy);
    }

    private void Update()
    {
        if (_enemies.Count != 0)
        {
            Debug.Log($"В списке: {_enemies.Count}");

            foreach (var enemy in _enemies)
            {
                enemy?.transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            }
        }
    }

}
