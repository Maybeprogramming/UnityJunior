using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    [SerializeField] private Transform _enemy;

    private void Update()
    {
        transform.LookAt(_enemy);
    }
}