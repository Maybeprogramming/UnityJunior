using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LifeCicleTime : MonoBehaviour
{
    [SerializeField] float timeToDestroy;

    void Start()
    {
        StartCoroutine(timeDelayToDestroy()) ;
    }

    IEnumerator timeDelayToDestroy()
    {
        while (timeToDestroy > 0)
        {
            timeToDestroy -= Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
