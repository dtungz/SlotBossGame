using System;
using UnityEngine;

public class StatManager : Singleton<StatManager>
{
    private int Attack = 10;
    private int Health = 10;
    private int Coint = 0;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(transform.root);
    }
    

    public void IncAttack(int value)
    {
        Attack += value;
    }
    public void ChangeHealth(int value)
    {
        Health += value;
    }

    public void IncCoint(int value)
    {
        Coint += value;
    }

    public int GetAttack()
    {
        return Attack;
    }

    public int GetHealth()
    {
        return Health;
    }

    public int GetCoint()
    {
        return Coint;
    }
    
}
