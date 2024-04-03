using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource)), RequireComponent(typeof(Detector))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private Detector _detector;

    private const float MaxVolume = 1f;
    private const float MinVolume = 0f;

    private AudioSource _audioSource;
    private Coroutine _alarmLeveling;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _detector = GetComponent<Detector>();
        _audioSource.volume = MinVolume;
        _audioSource.clip = _audioClip;
    }

    private void OnEnable()
    {
        _detector.ThiefEntered += OnTheifDetected;
        _detector.ThiefExited += OnThiefLost;
    }

    private void OnDisable()
    {
        _detector.ThiefEntered -= OnTheifDetected;
        _detector.ThiefExited -= OnThiefLost;
    }

    private void OnTheifDetected()
    {
        _audioSource.Play();
        Debug.Log($"AudioSource play status: {_audioSource.isPlaying}");
        TryChangeAlarmLeveling(MaxVolume);
    }

    private void OnThiefLost()
    {
        TryChangeAlarmLeveling(MinVolume);
    }

    private void TryChangeAlarmLeveling(float volumeValue)
    {
        if (_alarmLeveling != null)
        {
            StopCoroutine(_alarmLeveling);
        }

        _alarmLeveling = StartCoroutine(AlarmLeveling(volumeValue));
    }

    private IEnumerator AlarmLeveling(float targetVolume)
    {
        Debug.Log($"Coroutine running for target volume value: {targetVolume}");

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, Time.deltaTime * _speed);
            yield return null;
        }

        if(_audioSource.volume == MinVolume)
        {
            _audioSource.Stop();
           Debug.Log($"AudioSource play status: {_audioSource.isPlaying}");
        }
    }
}
