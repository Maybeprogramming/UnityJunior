using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpByCoroutinePlusCurve : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(nameof(Jumper));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        StopCoroutine(nameof(Jumper));
    }

    private IEnumerator Jumper()
    {
        float positionY = transform.position.y;

        while (_currentTime <= _totalTime)
        {
            _currentTime += Time.deltaTime;

            positionY = _jumpCurve.Evaluate(_currentTime);

            transform.position = new Vector3(transform.position.x, positionY, transform.position.z);

            yield return null;
        }

        _currentTime = 0;

        StopCoroutine(nameof(Jumper));
    }
}