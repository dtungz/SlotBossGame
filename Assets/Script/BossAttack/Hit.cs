using UnityEngine;

public class Hit : MonoBehaviour, IAttackable
{
    
    public void Attack(int value)
    {
        StatManager.Instance.ChangeHealth(-value);
    }
}
