using System;
using UnityEngine;

[RequireComponent(typeof(Explosable))]
public class CubesCreator : MonoBehaviour
{
    private const int MinCubeCount = 2;
    private const int MaxCubeCount = 6;
    private const float ScaleMultiplier = 0.5f;

    private static int s_id = 0;

    [SerializeField] private Explosable _prefabCube;

    private Explosable _cube;
    private int _maxChance = 100;
    private float _chanceMultiplier = 0.5f;
    private float _currentChance = 100;
    private static System.Random s_random = new System.Random();

    public event Action<Rigidbody[]> CubesCreated;

    public void Init(float chance)
    {
        _currentChance = chance;
    }

    private void Awake()
    {
        _cube = GetComponent<Explosable>();
        _cube.MouseDowned += OnTryCreateNewCubes;
    }

    private void Start()
    {
        gameObject.name = GetName();
    }

    private void OnDisable()
    {
        _cube.MouseDowned -= OnTryCreateNewCubes;
    }

    private void OnTryCreateNewCubes()
    {
        int chance = s_random.Next(++_maxChance);

        if (chance <= _currentChance)
        {
            _currentChance *= _chanceMultiplier;
            int randomCount = s_random.Next(MinCubeCount, MaxCubeCount + 1);
            Rigidbody[] cubesRigidbody = new Rigidbody[randomCount];

            for (int i = 0; i < randomCount; i++)
            {
                Explosable newCube = Instantiate(_prefabCube, transform.position + Vector3.up, transform.rotation);
                newCube.name = GetName();
                newCube.transform.localScale *= ScaleMultiplier;
                newCube.GetComponent<CubesCreator>().Init(_currentChance);

                cubesRigidbody[i] = newCube.GetComponent<Rigidbody>();
            }

            CubesCreated?.Invoke(cubesRigidbody);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private static string GetName()
    {
        s_id++;
        return $"Cube {s_id}";
    }
}
