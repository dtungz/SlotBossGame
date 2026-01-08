using UnityEngine;

[CreateAssetMenu(fileName = "BossStatSO", menuName = "ScriptableObjects/BossStatSO")]
public class BossStatSO : ScriptableObject
{
    public int MaxHp;
    public int Shield;
    public int DamageOnHit;
}
