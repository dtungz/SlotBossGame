using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    private float _timeLerp;
    private float duration = 0.5f;
    private Coroutine _healthBarCoroutine;
    private Health _health;

    private void Awake()
    {
        if (_healthBar == null)
        {
            _healthBar = GetComponent<Image>();
        }
    }

    public void SetBar(int start, int end, int maxHp)
    {
        if (_healthBarCoroutine == null)
        {
            _healthBarCoroutine = StartCoroutine(ControlBar(start, end, maxHp));
        }
    }


    IEnumerator ControlBar(int start, int end,int maxHp)
    {
        _timeLerp = 0;
        while (_timeLerp < duration)
        {
            float t = _timeLerp / duration;
            int current = (int)Mathf.Lerp(start, end, t);
            _healthBar.fillAmount = (float)current / maxHp;
            yield return null;
            _timeLerp += Time.deltaTime;
        }

        _healthBarCoroutine = null;
    }
}
    
