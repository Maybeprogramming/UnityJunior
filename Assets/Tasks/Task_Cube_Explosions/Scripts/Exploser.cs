using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        gameObject.name = GetName();
    }

    private void OnMouseUpAsButton()
    {
        Destroy(gameObject);
        Explose();
        CreateNewCubes();
    }

    private void CreateNewCubes()
    {
        int randomNumber = new System.Random().Next(MinCubeCount, MaxCubeCount + 1);

        Debug.Log(randomNumber);

        for (int i = 0; i < randomNumber; i++)
        {
            Transform newCube = Instantiate(_prefabCube, transform.position + Vector3.up, transform.rotation);
            newCube.localScale = newCube.localScale * ScaleMultiplier;
            newCube.name = GetName();
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
