using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CubesCreator))]
public class Exploser : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private ParticleSystem _particleEffect;

    private CubesCreator _cubesCreator;

    private void Awake()
    {
        _cubesCreator = GetComponent<CubesCreator>();
        _cubesCreator.CubesCreated += OnExplosed;
    }

    private void OnDisable()
    {
        _cubesCreator.CubesCreated -= OnExplosed;
    }

    private void OnExplosed(Rigidbody[] cubesRigidbodies)
    {
        foreach (Rigidbody cubeRigidbody in cubesRigidbodies)
        {
            cubeRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        PlayExploseEffect();
        Destroy(gameObject);
    }

    private void PlayExploseEffect()
    {
        Instantiate(_particleEffect, transform.position, Quaternion.Euler(Vector3.up));
    }
}