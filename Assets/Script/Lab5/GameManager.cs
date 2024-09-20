using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public HealtComponent playerHealthComponent;

    public event Action<float> OnPlayerTakeDamage;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float damage = 10f;
            PlayerTakeDamage(damage);
        }
    }

    private void PlayerTakeDamage(float damage)
    {
        OnPlayerTakeDamage?.Invoke(damage);
    }

    private void OnEnable()
    {
        OnPlayerTakeDamage += playerHealthComponent.TakeDamage;
    }

    private void OnDisable()
    {
        OnPlayerTakeDamage -= playerHealthComponent.TakeDamage;
    }
}
