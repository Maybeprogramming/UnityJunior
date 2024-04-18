using System;
using UnityEngine;

public class Explosable : MonoBehaviour 
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;
    [SerializeField] private float _forceGain;
    [SerializeField] private float _radiusGain;

    public event Action MouseDowned;

    public float Force => _force;
    public float Radius => _radius;

    public void EnhanceParameters()
    {
        _force += _forceGain;
        _radius += _radiusGain;
    }

    private void OnMouseDown()
    {
        MouseDowned?.Invoke();
    }
}