using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeCounterText;
    [SerializeField] private TextMeshProUGUI _currentCounterStateText;
    [SerializeField] private InputMouse _inputMouse;
    [SerializeField] private int _startCounterValue;
    [SerializeField] private float _durationTime;
    [SerializeField] private bool _isTimeCounterRun;

    private string _runState = "Запущен";
    private string _pauseState = "Пауза";

    private void Start()
    {
        _startCounterValue = 0;
        _durationTime = 0.5f;
        _timeCounterText.text = _startCounterValue.ToString();
        _isTimeCounterRun = false;
    }

    private void OnEnable()
    {
        _inputMouse.LeftButtonClicked += OnCounterRun;
    }

    private void OnDisable()
    {
        _inputMouse.LeftButtonClicked -= OnCounterRun;
    }

    private void OnCounterRun()
    {
        if (_isTimeCounterRun == false)
        {
            _isTimeCounterRun = true;
            StartCoroutine(TimeCounter());
            _currentCounterStateText.text = _runState;
            Debug.Log("Старт");
        }
        else
        {
            _isTimeCounterRun = false;
            StopCoroutine(TimeCounter());
            _currentCounterStateText.text = _pauseState;
            Debug.Log("Пауза");
        }
    }

    private IEnumerator TimeCounter()
    {
        float elapsedTime = 0f;
        int previousValue = int.Parse(_timeCounterText.text);

        while (_isTimeCounterRun == true)
        {
            if (elapsedTime < _durationTime)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                previousValue++;
                elapsedTime = 0f;
            }

            _timeCounterText.text = previousValue.ToString();
            yield return null;
        }
    }
}
