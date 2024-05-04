using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;

    public event Action<int> HealthChanged;

    public int Health => _health;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public bool TakeDamage(int damage)
    {
        if (_health <= 0)
            return false;

        int health = _health - damage;

        if (health > 0)
        {
            _health = health;
        }
        else
        {
            _health = 0;
        }

        HealthChanged?.Invoke(_health);

        return true;
    }

    public void GiveHealth(int health)
    {
        if (health <= 0)
            return;

        _health += health;

        HealthChanged?.Invoke(_health);
    }
}