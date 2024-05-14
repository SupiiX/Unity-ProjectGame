using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPositions;
    public float initialSpawnInterval = 5f;
    public float minSpawnInterval = 1f;
    public float intervalDecreaseRate = 0.1f;

    private float spawnInterval;
    private float lastSpawnTime = 0f;

    void Start()
    {
        spawnInterval = initialSpawnInterval;
    }

    void Update()
    {
        if (Time.time - lastSpawnTime >= spawnInterval)
        {
            SpawnEnemy();
            lastSpawnTime = Time.time;

            // Csökkentjük a spawnInterval értékét
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - intervalDecreaseRate);
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPositions.Length);
        Vector3 spawnPosition = spawnPositions[randomIndex].position;

        if (randomIndex == 0)
        {
            spawnPosition.x += Random.Range(0f, 5f);
        }
        else
        {
            spawnPosition.x += Random.Range(-2f, 0f);
        }

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
