using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class TestTimerScripts : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private void OnPrintMessage()
    {
        Debug.Log($"{DateTime.Now}");
    }

    private void OnEnable()
    {
        _timer.Tick += OnPrintMessage;
    }

    private void OnDisable()
    {
        _timer.Tick -= OnPrintMessage;        
    }
}
