using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour
{
    // Az enemy prefab
    public GameObject enemyPrefab;

    public Transform[] spawnPositions; // Több spawnpozíció

    // Az spawnolás idõköze
    public float spawnInterval = 5f;

    // Az utolsó spawnolás ideje
    private float lastSpawnTime = 0f;

    // Update függvény
    void Update()
    {
        // Idõ ellenõrzése
        if (Time.time - lastSpawnTime >= spawnInterval)
        {
            // Spawnolás
            SpawnEnemy();

            // Utolsó spawnolás ideje frissítése
            lastSpawnTime = Time.time;
        }
    }

    // Enemy spawnolása
    void SpawnEnemy()
    {
        // Véletlenszerûen válasszunk spawnpozíciót
        int randomIndex = Random.Range(0, spawnPositions.Length);
        Vector3 spawnPosition = spawnPositions[randomIndex].position;

        // Pozícionálás

        if (randomIndex == 0)
        {
            spawnPosition.x += Random.Range(0f, 5f);
        }
        else
        {
            spawnPosition.x += Random.Range(-2f, 0f);

        }

      

        // Spawnolás
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
