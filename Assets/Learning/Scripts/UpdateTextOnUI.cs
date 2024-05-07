using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TextMeshProUGUI))]
public class UpdateTextOnUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerHealth;

    private IDamageable _player;

    void Start()
    {
        _playerHealth = GetComponent<TextMeshProUGUI>();
        _player.HealthChanged += OnChangeText;
    }

    private void OnChangeText(int value)
    {
        _playerHealth.text = value.ToString();
    }

    public void Init(IDamageable player)
    {
        _player = player;
    }
}
