using UnityEngine;

public class DoubleHit : MonoBehaviour, IAttackable
{
    public void Attack(int value)
    {
        StatManager.Instance.ChangeHealth(-value * 2);
    }
}
