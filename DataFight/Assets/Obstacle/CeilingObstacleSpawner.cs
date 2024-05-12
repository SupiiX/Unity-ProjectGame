using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingObstacleSpawner : MonoBehaviour
{
    public GameObject Obstacle; // Obstacle prefab
    public Transform startPoint; // Start point
    public Transform endPoint; // End point
    public float minSpawnInterval; // Minimum spawn interval
    public float maxSpawnInterval; // Maximum spawn interval
    public GameObject player; // Player reference
    public float difficultyIncreaseRate = 0.1f; // Rate at which difficulty increases (0.1f = 10% decrease per second)

    private float currentSpawnInterval; // Current spawn interval
    private float nextSpawnTime; // Time for next obstacle spawn
    private float timeSinceStart = 0f; // Time elapsed since game start

    void Start()
    {
        currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        nextSpawnTime = Time.time + currentSpawnInterval;
    }

    void Update()
    {
        timeSinceStart += Time.deltaTime;

        // Update spawn interval based on difficulty increase rate
        currentSpawnInterval = Mathf.Max(minSpawnInterval, maxSpawnInterval - (difficultyIncreaseRate * timeSinceStart));

        // Check if it's time to spawn an obstacle
        if (Time.time >= nextSpawnTime)
        {
            Vector3 spawnPosition = new Vector3(player.transform.position.x, startPoint.position.y, 0f);
            GameObject newObstacle = Instantiate(Obstacle, spawnPosition, Quaternion.identity);

            Debug.DrawLine(player.transform.position, newObstacle.transform.position, Color.red, 3f);

            // Calculate next spawn time based on updated interval
            nextSpawnTime = Time.time + currentSpawnInterval;
        }
    }
}
