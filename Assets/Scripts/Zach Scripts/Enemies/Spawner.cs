using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] EnemyType enemyType;
    [SerializeField] Vector2 spawnPos;
    [SerializeField] float spawnInterval;
    [SerializeField] int spawnCap;
    [SerializeField] int spawned;
    EnemyFactory enemyFactory;

    void Start()
    {
        enemyFactory = new EnemyFactory();
        StartCoroutine(DelaySpawn());
    }
    IEnumerator DelaySpawn()
    {
        WaitForSeconds spawnDelay = new WaitForSeconds(spawnInterval);
        while (spawned < spawnCap)
        {
            yield return spawnDelay;
            SpawnEnemy();
            spawned++;
        }
    }
    private void SpawnEnemy()
    {
        enemyFactory.CreateEnemy(enemyType, spawnPos);
    }
}
