using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestNewInputSystem : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.localScale *= 2f;
    }

    private void OnEnable()
    {

    }
}
