using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _delayInSeconds;
    
    public event Action Triggered;

    private void Awake()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
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
                Triggered?.Invoke();
                elapsedTime = 0f;
                Debug.Log("Timer is triggered");
            }

            yield return null;
        }
    }
}
