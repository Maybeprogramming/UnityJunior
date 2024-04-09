using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TestRigid : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _templateBullet;
    [SerializeField] private Transform _target;
    [SerializeField] private float _delayShotTime;

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        bool isWork = true;

        while (isWork)
        {
            var direction = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_templateBullet, transform.position + direction, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = direction;
            newBullet.GetComponent<Rigidbody>().velocity = direction * _speed;

            yield return new WaitForSeconds(_delayShotTime);
        }
    }
}
