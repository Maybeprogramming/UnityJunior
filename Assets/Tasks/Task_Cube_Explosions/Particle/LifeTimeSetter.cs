using System.Collections;
using UnityEngine;

public class LifeTimeSetter : MonoBehaviour
{
    [SerializeField] private float duration;

    private Coroutine _lifeTimeToDestroy;

    void Start()
    {
        _lifeTimeToDestroy = StartCoroutine(DestroerByTime());        
    }

    //private void OnDestroy()
    //{
    //    StopCoroutine(_lifeTimeToDestroy);
    //    Debug.Log("Ёффект удалЄн со сцены");
    //}

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
