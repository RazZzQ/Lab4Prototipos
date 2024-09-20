using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PowerUpComponent : MonoBehaviour
{
    public int healingPotions = 3;
    public float healingAmount = 50f;

    public event Action OnPowerUpUsed;

    public void UsePowerUp()
    {
        if (healingPotions > 0)
        {
            healingPotions--;

            HealtComponent playerHealth = GetComponent<HealtComponent>();
            playerHealth.Heal(healingAmount);
            OnPowerUpUsed?.Invoke();
        }
    }

    public void AddPotion()
    {
        healingPotions++;
    }
}
