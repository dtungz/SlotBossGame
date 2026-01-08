using System;
using UnityEngine;

public class CasinoAction : MonoBehaviour
{
    [SerializeField] private Boss boss;
    [SerializeField] private ShowStat _Stat;
    
    public void Casino(int AttackValue, int HealthValue, int CointValue)
    {
        if (AttackValue > 0)
        {
            boss.OnAttack(AttackValue * StatManager.Instance.GetAttack());
        }

        if (HealthValue > 0)
        {
            StatManager.Instance.ChangeHealth(HealthValue);
            _Stat.ShowHealth();
        }

        if (CointValue > 0)
        {
            StatManager.Instance.IncCoint(CointValue);
            _Stat.ShowCoint();
        }
        boss.BossTurn();
    }
}
