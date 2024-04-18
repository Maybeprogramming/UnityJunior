using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CubesCreator))]
[RequireComponent(typeof(Explosable))]

public class Exploser : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private ParticleSystem _particleEffect;

    private CubesCreator _cubesCreator;
    private Explosable _cubeExplosable;

    private void Awake()
    {
        _cubeExplosable = GetComponent<Explosable>();
        _cubesCreator = GetComponent<CubesCreator>();
        _cubesCreator.CubesCreated += OnExplosed;
        _cubesCreator.CubesNotCreated += OnExplosedAround;
    }

    private void OnDisable()
    {
        _cubesCreator.CubesCreated -= OnExplosed;
        _cubesCreator.CubesNotCreated -= OnExplosedAround;
    }

    private void OnExplosed(Rigidbody[] cubesRigidbodies)
    {
        foreach (Rigidbody cubeRigidbody in cubesRigidbodies)
        {
            cubeRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        Destroy(gameObject);
    }

    private void OnExplosedAround()
    {
        List<Rigidbody> explodableCubes = GetExplodableCubes();
        float distanceToExplosableCube;
        float forceMultiplier;
        Vector3 forceDirection;

        foreach (Rigidbody cubeRigidbody in explodableCubes)
        {
            distanceToExplosableCube = (cubeRigidbody.transform.position - transform.position).magnitude;
            forceMultiplier = (distanceToExplosableCube / _cubeExplosable.Radius) * _cubeExplosable.Force;
            forceDirection = (cubeRigidbody.transform.position - transform.position).normalized;

            cubeRigidbody.AddForce(forceDirection * forceMultiplier, ForceMode.Force);
        }

        PlayExploseEffect();
        Destroy(gameObject);
    }

    private void PlayExploseEffect()
    {
        Instantiate(_particleEffect, transform.position, Quaternion.Euler(Vector3.up));
    }

    private List<Rigidbody> GetExplodableCubes()
    {
        float explosionRadius = _cubeExplosable.Radius;
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null && hit.GetComponent<Explosable>() == true)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}