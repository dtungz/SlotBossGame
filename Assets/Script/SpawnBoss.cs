using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField] private List<BossController> boss = new List<BossController>();
    [SerializeField] private CasinoAction casino;
    [SerializeField] private BossHealthBar healthBar;
    public int bossIndex = 0;
    private BossController _currentBoss;
    private Coroutine _spawnBossCoroutine;

    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (_spawnBossCoroutine == null)
        {
            _spawnBossCoroutine = StartCoroutine(SpawningBoss());
        }
    }
    
    IEnumerator SpawningBoss()
    {
        if (_currentBoss != null)
        {
            yield return new WaitForSeconds(0.6f);
            Destroy(_currentBoss.gameObject);
        }
        if (bossIndex < boss.Count)
        {
            _currentBoss = Instantiate(boss[bossIndex],transform.position, Quaternion.identity);
            bossIndex++;
            _currentBoss.dieEvent.AddListener(Spawn);
            casino.GetBoss(_currentBoss);
            _currentBoss._bossHealth.GetBar(healthBar);
            _spawnBossCoroutine = null;
        }
        else
        {
            Debug.Log("No more boss enemies");
        }
    }
    
}
