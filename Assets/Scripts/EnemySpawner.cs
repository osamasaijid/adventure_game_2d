using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 3f; // Time in seconds between each spawn
    public float spawnRadius = 5f; // Range within which enemies can spawn
    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }
    void SpawnEnemy()
    {
        Vector2 spawnPos = Random.insideUnitCircle * spawnRadius + (Vector2)transform.position;
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
