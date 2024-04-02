using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _delayInSeconds;
    [SerializeField] public event Action Tick;

    private void Awake()
    {
        StartCoroutine(TimeCounter());
    }

    private IEnumerator TimeCounter()
    {
        Debug.Log("Timer already run!");

        float elapsedTime = 0f;

        while (true)
        {
            if (elapsedTime < _delayInSeconds)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                Tick?.Invoke();
                elapsedTime = 0f;
            }

            yield return null;
        }
    }
}
