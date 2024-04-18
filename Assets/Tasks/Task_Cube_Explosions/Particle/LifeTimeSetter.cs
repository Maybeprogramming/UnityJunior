using System.Collections;
using UnityEngine;

public class LifeTimeSetter : MonoBehaviour
{
    [SerializeField] private float duration;

    private Coroutine _timerToDestroy;

    void Start()
    {
        _timerToDestroy = StartCoroutine(DestroerByTime());
    }

    private void OnDestroy()
    {
        StopCoroutine(_timerToDestroy);
    }

    private IEnumerator DestroerByTime()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
