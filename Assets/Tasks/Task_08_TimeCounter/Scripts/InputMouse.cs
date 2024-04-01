using UnityEngine;
using System;

public class InputMouse : MonoBehaviour
{
    [SerializeField] public event Action LeftButtonClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            LeftButtonClicked?.Invoke();
            Debug.Log($"ЛКМ - нажата. Есть ли подписчики на событие LeftButtonClecked: <{LeftButtonClicked != null}>");
        }
    }
}
