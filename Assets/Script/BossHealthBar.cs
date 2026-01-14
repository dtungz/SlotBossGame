using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    private float _timeLerp;
    private float duration = 0.5f;
    private Tween _tween;
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
        if (_tween.isAlive) return;
        _tween = Tween.Custom(start, end, duration: duration, onValueChange: newVal => _healthBar.fillAmount = newVal/maxHp);
        
    }
}
    
