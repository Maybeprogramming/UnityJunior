using System;
using UnityEngine;

public class Explosable : MonoBehaviour 
{
    public event Action MouseDowned;

    private void OnMouseDown()
    {
        MouseDowned?.Invoke();
    }
}