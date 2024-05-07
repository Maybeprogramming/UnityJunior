using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpByCurve : MonoBehaviour
{
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private float _currentTime;
    [SerializeField] private float _totalTime;

    private void Start()
    {
        _totalTime = _jumpCurve.keys[_jumpCurve.length - 1].time;
    }

    private void Update()
    {
        var position = transform.position;
        position.y = _jumpCurve.Evaluate(_currentTime);
        transform.position = position;

        _currentTime += Time.deltaTime;

        if (_currentTime >= _totalTime)
        {
            _currentTime = 0;
        }
    }
}