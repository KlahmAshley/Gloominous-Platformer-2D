using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] EnemyType enemyType;
    [SerializeField] Vector2 spawnPos;
    [SerializeField] float spawnInterval;
    EnemyFactory enemyFactory = new EnemyFactory();

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DelaySpawn()
    {
        WaitForSeconds spawnDelay = new WaitForSeconds(spawnInterval);
        while (GameManager.Instance.isGamePaused == false)
        {
            yield return spawnDelay;
            SpawnEnemy();
        }
    }
    private void SpawnEnemy()
    {
        
    }
}
