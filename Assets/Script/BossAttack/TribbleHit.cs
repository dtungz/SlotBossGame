using UnityEngine;

public class TribbleHit : MonoBehaviour, IAttackable
{
    public void Attack(int value)
    {
        StatManager.Instance.ChangeHealth(-value * 3);
    }
}
