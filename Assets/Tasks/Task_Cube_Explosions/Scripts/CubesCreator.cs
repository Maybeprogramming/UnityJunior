using UnityEngine;

[RequireComponent(typeof(Explosable))]
public class CubesCreator : MonoBehaviour
{
    private const int MinCubeCount = 2;
    private const int MaxCubeCount = 6;
    private const float ScaleMultiplier = 0.5f;

    private static int ID = 0;

    [SerializeField] private Explosable _prefabCube;

    private Explosable _cube;
    private int _maxChance = 100;
    private float _chanceMultiplier = 0.5f;
    private float _currentChance = 100;
    private System.Random _random = new System.Random();

    public void Init(float chance)
    {
        _currentChance = chance;
    }

    private void Awake()
    {
        _cube = GetComponent<Explosable>();
        _cube.OnMouseDowned += TryCreateNewCubes;
    }

    private void Start()
    {
        gameObject.name = GetName();
    }

    private void OnDisable()
    {
        _cube.OnMouseDowned -= TryCreateNewCubes;
    }

    private void TryCreateNewCubes()
    {
        int chance = _random.Next(_maxChance + 1);

        if (chance <= _currentChance)
        {
            _currentChance *= _chanceMultiplier;
            int randomCount = _random.Next(MinCubeCount, MaxCubeCount + 1);

            for (int i = 0; i < randomCount; i++)
            {
                Explosable newCube = Instantiate(_prefabCube, transform.position + Vector3.up, transform.rotation);
                newCube.name = GetName();
                newCube.transform.localScale = newCube.transform.localScale * ScaleMultiplier;
                newCube.GetComponent<CubesCreator>().Init(_currentChance);
            }
        }
    }

    private static string GetName()
    {
        ID++;
        return $"Cube {ID}";
    }
}
