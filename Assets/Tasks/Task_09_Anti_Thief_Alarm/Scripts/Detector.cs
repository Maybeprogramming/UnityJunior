using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public event Action ThiefEntered;
    public event Action ThiefExited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Thief>() == true)
        {
            Debug.Log("The detector detected a Thief!");
            ThiefEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Thief>() == true)
        {
            Debug.Log("The detector lost a Thief!");
            ThiefExited?.Invoke();
        }
    }
}
