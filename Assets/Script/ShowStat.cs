using System;
using TMPro;
using UnityEngine;

public class ShowStat : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _AttackValue;
    [SerializeField] TextMeshProUGUI _HealthValue;
    [SerializeField] TextMeshProUGUI _CointValue;

    void Start()
    {
        ShowAttack();
        ShowHealth();
        ShowCoint();
    }

    public void ShowAttack()
    {
        _AttackValue.text = "Attack value: " + StatManager.Instance.GetAttack();
    }

    public void ShowHealth()
    {
        _HealthValue.text = "Health value: " + StatManager.Instance.GetHealth();
    }

    public void ShowCoint()
    {
        _CointValue.text = "Coint value: " + StatManager.Instance.GetCoint();
    }
}
