using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingObstacleSpawner : MonoBehaviour
{
    public GameObject Obstacle; 
    public Transform startPoint; 
    public Transform endPoint;
    public float minSpawnInterval; 
    public float maxSpawnInterval; 
    public GameObject player; 
    public float difficultyIncreaseRate = 0.1f;
    private float currentSpawnInterval; 
    private float nextSpawnTime; 
    private float timeSinceStart = 0f; 

    void Start()
    {
        currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        nextSpawnTime = Time.time + currentSpawnInterval;
    }

    void Update()
    {
        timeSinceStart += Time.deltaTime;

        
        currentSpawnInterval = Mathf.Max(minSpawnInterval, maxSpawnInterval - (difficultyIncreaseRate * timeSinceStart));

        
        if (Time.time >= nextSpawnTime)
        {
            Vector3 spawnPosition = new Vector3(player.transform.position.x, startPoint.position.y, 0f);
            GameObject newObstacle = Instantiate(Obstacle, spawnPosition, Quaternion.identity);

            Debug.DrawLine(player.transform.position, newObstacle.transform.position, Color.red, 3f);

            
            nextSpawnTime = Time.time + currentSpawnInterval;
        }
    }
}
