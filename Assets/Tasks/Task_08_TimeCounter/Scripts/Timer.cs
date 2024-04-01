using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeCounterText;
    [SerializeField] private InputMouse _inputMouse;
    [SerializeField] private float _startTimeValue;
    [SerializeField] private bool _isTimeCounterRun;

    private IEnumerator _timeCounter;

    private void Start()
    {
        _startTimeValue = 0f;
        _timeCounterText.text = _startTimeValue.ToString();
        _isTimeCounterRun = false;
    }

    private void OnEnable()
    {
        _inputMouse.LeftButtonClicked += OnTimeCounterÑalculation;
    }

    private void OnDisable()
    {
        _inputMouse.LeftButtonClicked -= OnTimeCounterÑalculation;
    }

    private void OnTimeCounterÑalculation()
    {
        if (_isTimeCounterRun == false)
        {
            StartCoroutine(TimeCounter(_startTimeValue));
            _isTimeCounterRun = true;
            Debug.Log("Ñòàðò");
        }
        else
        {
            StopCoroutine(nameof(TimeCounter));
            _isTimeCounterRun = false;
            Debug.Log("Ïàóçà");
        }
    }

    private IEnumerator TimeCounter(float previousTime)
    {
        float elapsedTime = 0f;
        float previousTimeValue = float.Parse(_timeCounterText.text);
        Debug.Log($"Ñòàðò êîðóòèíû: {previousTime}f");

        while (_isTimeCounterRun == true)
        {
            elapsedTime += Time.deltaTime;
            previousTimeValue += elapsedTime;

            _timeCounterText.text = previousTimeValue.ToString();

            yield return null;
        }
    }
}
