using System;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public event Action CollisionDetected;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Ground>() == true)
        {
            Detected();
        }
    }

    private void Detected()
    {
        CollisionDetected?.Invoke();
    }
}