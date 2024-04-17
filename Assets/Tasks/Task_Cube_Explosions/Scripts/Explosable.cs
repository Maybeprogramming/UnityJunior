using System;
using UnityEngine;

public class Explosable : MonoBehaviour 
{
    public event Action OnMouseDowned;

    private void OnMouseDown()
    {
        OnMouseDowned?.Invoke();
    }
}