using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Explosable))]
public class Exploser : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private ParticleSystem _particleEffect;

    private Explosable _cube;

    private void Awake()
    {
        _cube = GetComponent<Explosable>();
        _cube.OnMouseDowned += Explose;
    }

    private void OnDisable()
    {
        _cube.OnMouseDowned -= Explose;
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

        PlayExploseEffect();
        Destroy(gameObject);
    }

    private void PlayExploseEffect()
    {
        Instantiate(_particleEffect, transform.position, Quaternion.Euler(Vector3.up));
    }
}