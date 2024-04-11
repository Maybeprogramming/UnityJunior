using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;
    [SerializeField] private float _delayShotTime;
    [SerializeField] private Bullet _prefabBullet;

    private Coroutine _shoot;
    private WaitForSeconds _delayShot;

    private void Start()
    {
        _delayShot = new WaitForSeconds(_delayShotTime);
        _shoot = StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        StopCoroutine(_shoot);
    }

    private IEnumerator Shoot()
    {
        bool isWork = true;
        Rigidbody newBulletRigidbody;

        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_prefabBullet, transform.position + direction, Quaternion.identity);

            if (newBullet.TryGetComponent<Rigidbody>(out newBulletRigidbody) == false)
            {
                newBullet.AddComponent<Rigidbody>();
                newBulletRigidbody = newBullet.GetComponent<Rigidbody>();
            }

            newBulletRigidbody.velocity = direction * _speed;

            yield return _delayShot;
        }
    }
}