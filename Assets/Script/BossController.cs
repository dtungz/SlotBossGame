using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BossController : MonoBehaviour
{
    public Health _bossHealth;
    public IAttackable _bossAttack;
    [SerializeField] private int damage;
    [SerializeField] private int health;
    public UnityEvent dieEvent;

    private void OnEnable()
    {
        _bossHealth = GetComponent<Health>();
        _bossAttack = GetComponent<IAttackable>();
        if (_bossAttack == null || _bossAttack == null)
        {
            Debug.Log("Thieu Reference");
        }
    }

    private void Start()
    {
        _bossHealth.SetHealth(health);
    }

    public void TakeDamage(int value)
    {
        _bossHealth.TakeDamage(value);
        if (_bossHealth.IsDead())
        {
            Die();
        }
    }
    
    private void Die()
    {
        dieEvent?.Invoke();
    }

    public void Attack()
    {
        _bossAttack.Attack(damage);
    }
}
