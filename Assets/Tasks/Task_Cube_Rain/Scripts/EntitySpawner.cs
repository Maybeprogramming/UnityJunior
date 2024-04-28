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
    [SerializeField] private int _poolSize;
    [SerializeField] private bool AutoExpandPool;

    private EntitiesPool<ColorableEntity> _pool;
    private int _timeDivider = 1000;
    private Vector3 _randomSpawnPosition;
    private WaitForSeconds _delayTimeOnNewSpawn;

    private void Awake()
    {
        _pool = new(_entityPrefab, _poolSize, gameObject.transform);
        _pool.SetAutoExpand(AutoExpandPool);
    }

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
            _randomSpawnPosition = GetRandomPosition();
            ColorableEntity cube = _pool.GetFreeElement();
            cube.transform.position = _randomSpawnPosition;

            yield return _delayTimeOnNewSpawn;
        }
    }
}