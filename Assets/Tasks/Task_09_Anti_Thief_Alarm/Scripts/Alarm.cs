using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private AudioClip _audioClip;

    private const float MaxVolume = 1f;
    private const float MinVolume = 0f;

    private AudioSource _audioSource;
    private IEnumerator _alarmLeveling;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = MinVolume;
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player at Home!");

        TryChangeAlarmLeveling(MaxVolume);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player at Outside!");

        TryChangeAlarmLeveling(MinVolume);
    }

    private void TryChangeAlarmLeveling(float volumeValue)
    {
        if (_alarmLeveling != null)
        {
            StopCoroutine(_alarmLeveling);
        }

        _alarmLeveling = AlarmLeveling(volumeValue);
        StartCoroutine(_alarmLeveling);
    }

    private IEnumerator AlarmLeveling(float targetVolume)
    {
        Debug.Log($"Coroutine running for target volume value: {targetVolume}");

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, Time.deltaTime * _speed);
            yield return null;
        }
    }
}
