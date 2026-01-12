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
    [SerializeField] private Animator animator;
    public UnityEvent dieEvent;

    private void OnEnable()
    {
        _bossHealth = GetComponent<Health>();
        _bossAttack = GetComponent<IAttackable>();
        animator = GetComponent<Animator>();
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
        animator.SetTrigger("Hurt");
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
        //Debug.Log("Enemy Attack");
        if(_bossHealth.IsDead())
            return;
        animator.SetTrigger("Attack");
        _bossAttack.Attack(damage);
    }
}
