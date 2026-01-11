using System;
using UnityEngine;
using UnityEngine.Events;

public class StatManager : Singleton<StatManager>
{
    private int Attack = 10;
    private int Health = 10;
    private int Coint = 0;
    
    public UnityEvent onStateChange = new UnityEvent();
    
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(transform.root);
    }
    

    public void ChangeAttack(int value)
    {
        Attack += value;
        onStateChange?.Invoke();
        
    }
    public void ChangeHealth(int value)
    {
        Health += value;
        onStateChange?.Invoke();
    }

    public void ChangeCoint(int value)
    {
        Coint += value;
        onStateChange?.Invoke();
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
