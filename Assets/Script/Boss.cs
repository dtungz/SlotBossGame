using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField] Image HealthBar;
    [SerializeField] List<BossStatSO> Stats = new List<BossStatSO>();
    [SerializeField] UnityEvent Attack; 
    int BossHP;
    int BossDamage;
    int currentHealth;
    public int currentBoss = 0;
    [Header("Health Bar")]
    public float duration;
    private float timeLearp = 0;
    
    

    private void Start()
    {
        BossHP = Stats[currentBoss].MaxHp;
        currentHealth = BossHP;
        BossDamage = Stats[currentBoss].DamageOnHit;
    }

    public void OnAttack(int damage)
    {
        currentHealth -= damage;
        HealthBar.fillAmount = (float)currentHealth / BossHP;
        Debug.Log("BossHp is : " + currentHealth);
        if (currentHealth <= 0)
        {
            OnDeath();
        }
    }

    public void BossTurn()
    {
        StartCoroutine(Attacked());
    }

    void OnDeath()
    {
        if (currentBoss == Stats.Count - 1) return;
        currentBoss++;
        BossHP = Stats[currentBoss].MaxHp;
        BossDamage = Stats[currentBoss].DamageOnHit;
        StartCoroutine(ResetBar());
    }

    IEnumerator ResetBar()
    {
        timeLearp = 0;
        while (timeLearp < duration)
        {
            float t = timeLearp/duration;
            HealthBar.fillAmount = t;
            timeLearp += Time.deltaTime;
            yield return null;
        }
        HealthBar.fillAmount = 1f;
        currentHealth = BossHP;
    }

    IEnumerator Attacked()
    {
        yield return new WaitForSeconds(1f);
        StatManager.Instance.ChangeHealth(-BossDamage);
        Attack.Invoke();
    }
}
