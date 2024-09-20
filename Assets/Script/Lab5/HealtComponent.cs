using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealtComponent : Damageable
{
    [SerializeField] float regenRate;
    public bool isRegenerating;
    public event Action<float> OnHealthChanged;
    public event Action OnPlayerDeath;

    private void Start()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            OnPlayerDeath?.Invoke();
        }

        isRegenerating = false;
    }

    public override void Heal(float amount)
    {
        base.Heal(amount);
        OnHealthChanged?.Invoke(currentHealth);
    }

    public void StartRegeneration()
    {
        isRegenerating = true;
    }

    public void Regenerate()
    {
        if (isRegenerating)
        {
            Heal(regenRate);
            OnHealthChanged?.Invoke(currentHealth);
        }
    }
}
