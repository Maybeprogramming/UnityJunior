using UnityEngine;
using System;

public class InputMouse_Exp : MonoBehaviour
{
    [SerializeField] public event Action LeftButtonClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            LeftButtonClicked?.Invoke();
        }
    }
}
