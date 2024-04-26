using System.Collections;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private ColorableEntity _entityPrefab;
    [SerializeField] private float _startPositionX;
    [SerializeField] private float _endPositionX;
    [SerializeField] private float _startPositionZ;
    [SerializeField] private float _endPositionZ;
    [SerializeField] private float _timeDelayMiliseconds;

    private int _timeDivider = 1000;
    private Vector3 _spawnPosition;
    private WaitForSeconds _delayTimeOnNewSpawn;

    private void Start()
    {
        _timeDelayMiliseconds /= _timeDivider;
        _delayTimeOnNewSpawn = new WaitForSeconds(_timeDelayMiliseconds);
        StartCoroutine(Spawner());
    }

    private Vector3 GetRandomPosition()
    {
        float spawnPositionX = Random.Range(_startPositionX, _endPositionX + 1);
        float spawnPositionZ = Random.Range(_startPositionZ, _endPositionZ + 1);

        return new Vector3(spawnPositionX, transform.position.y, spawnPositionZ);
    }

    private IEnumerator Spawner()
    {
        bool isSpawnerWork = true;

        while (isSpawnerWork == true)
        {
            _spawnPosition = GetRandomPosition();
            Instantiate(_entityPrefab, _spawnPosition, _entityPrefab.transform.rotation);

            yield return _delayTimeOnNewSpawn;
        }
    }
}