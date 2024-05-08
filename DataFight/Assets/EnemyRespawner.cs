using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour
{
    // Az enemy prefab
    public GameObject enemyPrefab;

    public Transform SpawnPosition;

    // Az spawnol�s id�k�ze
    public float spawnInterval = 5f;

    // Az utols� spawnol�s ideje
    private float lastSpawnTime = 0f;

    // Update f�ggv�ny
    void Update()
    {
        // Id� ellen�rz�se
        if (Time.time - lastSpawnTime >= spawnInterval)
        {
            // Spawnol�s
            SpawnEnemy();

            // Utols� spawnol�s ideje friss�t�se
            lastSpawnTime = Time.time;
        }
    }

    // Enemy spawnol�sa
    void SpawnEnemy()
    {
        // Pozicion�l�s
        Vector3 spawnPosition = SpawnPosition.position;
        spawnPosition.x += Random.Range(-5f, 5f);

        // Spawnol�s
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
