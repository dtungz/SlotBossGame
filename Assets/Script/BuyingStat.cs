using UnityEngine;

public class BuyingStat : MonoBehaviour
{
    public void BuyingAttack(int value)
    {
        if(StatManager.Instance.GetCoint() > 0)
        {
            StatManager.Instance.IncCoint(-value);
            StatManager.Instance.IncAttack(value);
        }
    }

    public void BuyingHealth(int value)
    {
        if (StatManager.Instance.GetCoint() > 0)
        {
            StatManager.Instance.IncCoint(-value);
            StatManager.Instance.ChangeHealth(value);
        }
    }
}
