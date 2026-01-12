using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CasinoAction : MonoBehaviour
{
    //private BossController _boss;
    [SerializeField] private ShowStat _Stat;
    BossController _currentBoss;
    
    public void Casino(int attackValue, int healthValue, int cointValue)
    {
        if (attackValue > 0)
        {
            _currentBoss.TakeDamage(attackValue * StatManager.Instance.GetAttack());
        }

        if (healthValue > 0)
        {
            StatManager.Instance.ChangeHealth(healthValue);
        }

        if (cointValue > 0)
        {
            StatManager.Instance.ChangeCoint(cointValue);
        }
        //_currentBoss.Attack();
        StartCoroutine(BossTurnAttack());
    }

    IEnumerator BossTurnAttack()
    {
      yield return new WaitForSeconds(0.5f);
      _currentBoss.Attack();
    }
    
    public void GetBoss(BossController boss)
    {
        _currentBoss = boss;
    }
}
