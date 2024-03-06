using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private Vector3 _specifiedScale;
    [SerializeField, Range(1, 5000)] private float _speed;

    private float _speedDivider;

    void Start()
    {
        _speedDivider = 1000;
    }

    void Update()
    {
        var nextScale = transform.localScale + ((_specifiedScale - transform.localScale) * Time.deltaTime * _speed / _speedDivider);
        transform.localScale = nextScale;
    }
}
