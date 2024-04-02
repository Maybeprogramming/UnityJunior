using System.Collections;
using TMPro;
using UnityEngine;

public class Counter_Exp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeCounterText;
    [SerializeField] private TextMeshProUGUI _currentCounterStateText;
    [SerializeField] private InputMouse_Exp _inputMouse;
    [SerializeField] private int _startCounterValue;
    [SerializeField] private float _durationTime;
    [SerializeField] private bool _isTimeCounterRun;

    //exp
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField, Range(0,1)] private float _volume;


    private string _runState = "Запущен";
    private string _pauseState = "Пауза";

    private void Start()
    {
        _audioSource.clip = _audioClip;
        _startCounterValue = 0;
        _timeCounterText.text = _startCounterValue.ToString();
        _isTimeCounterRun = false;
    }

    //exp
    private void Update()
    {
        _audioSource.volume = _volume;
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
                _audioSource.Play();
            }

            _timeCounterText.text = previousValue.ToString();
            yield return null;
        }
    }
}
