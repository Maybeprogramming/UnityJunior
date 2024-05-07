using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPointer : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private EnemyAttaker _enemyAttaker;
    [SerializeField] private UpdateTextOnUI _updateTextOnUI;

    private void Awake()
    {
        _enemyAttaker.Init(_playerHealth);
        _updateTextOnUI.Init(_playerHealth);
    }
}
