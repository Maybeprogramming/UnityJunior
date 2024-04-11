using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;
    [SerializeField] private float _delayShotTime;
    [SerializeField] private Bullet _prefabBullet;

    private Coroutine _shoot;

    private void Start()
    {
        _shoot = StartCoroutine(Shoot());
    }

    private void OnDisable()
    {
        StopCoroutine(_shoot);
    }

    private IEnumerator Shoot()
    {
        bool isWork = true;

        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_prefabBullet, transform.position + direction, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().transform.up = direction;
            newBullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return new WaitForSeconds(_delayShotTime);
        }
    }
}