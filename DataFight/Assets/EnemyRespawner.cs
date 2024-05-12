using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour
{
    // Az enemy prefab
    public GameObject enemyPrefab;

    public Transform[] spawnPositions; // T�bb spawnpoz�ci�

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
        // V�letlenszer�en v�lasszunk spawnpoz�ci�t
        int randomIndex = Random.Range(0, spawnPositions.Length);
        Vector3 spawnPosition = spawnPositions[randomIndex].position;

        // Poz�cion�l�s

        if (randomIndex == 0)
        {
            spawnPosition.x += Random.Range(0f, 5f);
        }
        else
        {
            spawnPosition.x += Random.Range(-2f, 0f);

        }

      

        // Spawnol�s
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
