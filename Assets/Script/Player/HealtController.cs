using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealtController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Life;
    public PlayerHealth health;
    public ChangeColorPlayer changeColorPlayer;
    public PlayerCollectablesCollision HeartCollision;
    public event Action DeathPlayer;
    // Start is called before the first frame update
    void Start()
    {
        health.MaxLife = 10;
        health.CurrentLife = health.MaxLife;
        UpdateLifeUI();
    }
    private void OnEnable()
    {
        changeColorPlayer.damagedPlayer += ActivateDamage;
        HeartCollision.CollisionHeart += ActivateHeal;
    }
    private void OnDisable()
    {
        changeColorPlayer.damagedPlayer -= ActivateDamage;
        HeartCollision.CollisionHeart -= ActivateHeal;
    }

    // Update is called once per frame
    void Update()
    {
        if(health.CurrentLife <= 0)
        {
            DeathPlayer?.Invoke();
        }   
    }
    public void ActivateDamage()
    {
        TakeDamage(1);
    }
    public void ActivateHeal()
    {
        HealPlayer(1);
    }
    public void HealPlayer(int Heal)
    {
        health.CurrentLife += Heal;
        UpdateLifeUI();
    }
    public void TakeDamage(int damage)
    {
        health.CurrentLife -= damage;
        UpdateLifeUI();
    }
    private void UpdateLifeUI()
    {
        Life.text = "Life: " + health.CurrentLife.ToString();  // Actualiza el texto de la UI
    }
}
