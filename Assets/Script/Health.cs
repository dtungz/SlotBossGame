using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, ITakeDamageable
{
    private int health;
    BossHealthBar _bossHealthBar;
    [Header("Health")]
    public int currentHealth;
    //public UnityEvent onDeath;

    public void SetHealth(int value)
    {
        health = value;
        currentHealth = health;
        _bossHealthBar.SetBar(0, health, health);
    }

    public void TakeDamage(int damage)
    {
        _bossHealthBar.SetBar(currentHealth, currentHealth - damage, health);
        currentHealth -= damage;
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
    
    public void GetBar(BossHealthBar bar)
    {
        _bossHealthBar = bar;
    }
}
