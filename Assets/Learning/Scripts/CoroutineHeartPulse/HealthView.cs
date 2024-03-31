using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    [SerializeField] private float _smoothDecreaseDuration = 0.5f;
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _textHealth;
    [SerializeField] private Color _damageHealthColor;
    [SerializeField] private AnimationCurve _colorBehaviour;
    [SerializeField] private Animator _heartAnimator;
    [SerializeField] private AnimationClip _heartPulseAnimation;

    private Color _originalHealthColor;

    void Start()
    {
        _originalHealthColor = _textHealth.color;
        _textHealth.text = _health.MaxHealth.ToString();
    }

    private void OnEnable()
    {
        _health.Changed += TakeDamage;
    }

    private void OnDisable()
    {
        _health.Changed -= TakeDamage;
    }

    private void TakeDamage(float currentHealth)
    {
        _heartAnimator.Play(_heartPulseAnimation.name);
        StartCoroutine(DecreaseHealth(currentHealth));
    }

    private IEnumerator DecreaseHealth(float target)
    {
        float elapsedTime = 0f;
        float previousValue = float.Parse(_textHealth.text);

        while (elapsedTime < _smoothDecreaseDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedPosition = elapsedTime / _smoothDecreaseDuration;
            float intermediateValue = Mathf.Lerp(previousValue, target, normalizedPosition);

            _textHealth.text = ((Int32)intermediateValue).ToString();

            _textHealth.color = Color.Lerp(_originalHealthColor, _damageHealthColor, _colorBehaviour.Evaluate(normalizedPosition));

            yield return null;
        }
    }
}
