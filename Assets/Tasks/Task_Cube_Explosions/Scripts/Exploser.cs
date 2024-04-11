using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Exploser : MonoBehaviour
{
    [SerializeField] private Transform _prefabCube;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private const int MinCubeCount = 2;
    private const int MaxCubeCount = 4;
    private const float ScaleMultiplier = 0.5f;

    private static int ID = 0;

    private int _maxChance = 100;
    private float _chanceMultiplier = 0.5f;
    private float _currentChance;
    private System.Random _random = new System.Random();

    public void Init(float chance)
    {
        _currentChance = chance;
    }

    private void Start()
    {
        gameObject.name = GetName();
        _currentChance = _maxChance;
    }

    private void OnMouseUpAsButton()
    {
        Destroy(gameObject);
        Explose();
        TryCreateNewCubes();
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
                Transform newCube = Instantiate(_prefabCube, transform.position + Vector3.up, transform.rotation);
                newCube.localScale = newCube.localScale * ScaleMultiplier;
                newCube.name = GetName();
                newCube.GetComponent<Exploser>().Init(_currentChance);
            }
        }             
    }

    private void Explose()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                hit.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
    }

    private static string GetName()
    {
        ID++;
        return $"Cube {ID}";
    }
}