using System;

public interface IDamageable
{
    public int Health { get; }

    public event Action<int> HealthChanged;

    public bool TakeDamage(int damage);
    public void GiveHealth(int health);
}