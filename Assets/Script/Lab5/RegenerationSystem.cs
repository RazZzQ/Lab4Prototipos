using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class RegenerationSystem : MonoBehaviour
{
    public HealtComponent healthComponent;
    public float regenerationDelay = 5f;
    [SerializeField] private float timeSinceLastDamage;
    public float regenAmountPerSecond = 5f;

    public event Action OnRegenStart;
    public event Action OnRegenEnd;

    private void OnEnable()
    {
        healthComponent.OnHealthChanged += ResetRegenTimer;
    }

    private void OnDisable()
    {
        healthComponent.OnHealthChanged -= ResetRegenTimer;
    }

    private void Update()
    {
        if (timeSinceLastDamage >= regenerationDelay && !healthComponent.isRegenerating)
        {
            StartRegeneration();
            OnRegenStart?.Invoke();
        }
        else
        {
            timeSinceLastDamage += Time.deltaTime;
        }
    }

    private void ResetRegenTimer(float currentHealth)
    {
        timeSinceLastDamage = 0;
        healthComponent.isRegenerating = false;
    }

    private void StartRegeneration()
    {
        healthComponent.isRegenerating = true;
        Regenerate();
        if(healthComponent.currentHealth == 100)
        {
            OnRegenEnd?.Invoke();
        }
    }

    private void Regenerate()
    {
        healthComponent.Regenerate();
    }
}
