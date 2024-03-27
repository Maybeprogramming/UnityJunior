using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Vector3 _rotationAngle;

    void Update()
    {
        var nextRotationAngle = _rotationAngle * _rotationSpeed * Time.deltaTime;
        transform.Rotate(nextRotationAngle);
    }
}
