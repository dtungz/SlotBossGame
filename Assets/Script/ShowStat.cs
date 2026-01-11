using System;
using TMPro;
using UnityEngine;

public class ShowStat : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _AttackValue;
    [SerializeField] TextMeshProUGUI _HealthValue;
    [SerializeField] TextMeshProUGUI _CointValue;

    void OnEnable()
    {
        StatManager.Instance.onStateChange.AddListener(UpdateUI);
        UpdateUI();
    }

    public void UpdateUI()
    {
        _AttackValue.text = "Attack value: " + StatManager.Instance.GetAttack();
        _HealthValue.text = "Health value: " + StatManager.Instance.GetHealth();
        _CointValue.text = "Coint value: " + StatManager.Instance.GetCoint();
    }
}
