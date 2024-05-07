using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LigthningByCurve : MonoBehaviour
{
    [SerializeField] private AnimationCurve _lightIntensityCurve;
    [SerializeField] private float _currentTime;
    [SerializeField] private float _totalTime;

    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();
        _totalTime = _lightIntensityCurve.keys[_lightIntensityCurve.length - 1].time;
    }

    private void Update()
    {
        _light.intensity = _lightIntensityCurve.Evaluate(_currentTime);

        _currentTime += Time.deltaTime / 2;

        if (_currentTime >= _totalTime)
        {
            _currentTime = 0;
        }
    }
}