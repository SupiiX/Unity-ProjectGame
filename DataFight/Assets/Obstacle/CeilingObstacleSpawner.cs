using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingObstacleSpawner : MonoBehaviour
{
    public GameObject Obstacle; // Az akadály prefabja
    public Transform startPoint; // Kezdõpont, ahol az akadályok megjelennek
    public Transform endPoint; // Végpont, ahol az akadályok véget érnek
    public float minSpawnInterval = 1f; // Minimum idõköz az akadályok között
    public float maxSpawnInterval = 3f; // Maximum idõköz az akadályok között

    private float nextSpawnTime; // Az idõ, amikor a következõ akadályt létre kell hozni

    void Start()
    {
        // Beállítjuk az elsõ akadály létrehozásának idõpontját
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {
        // Ellenõrizzük, hogy elérkezett-e az idõ a következõ akadály létrehozására
        if (Time.time >= nextSpawnTime)
        {
            // Létrehozzuk az akadályt a kezdõpont és végpont között
            Vector3 spawnPosition = new Vector3(Random.Range(startPoint.position.x, endPoint.position.x), startPoint.position.y, 0f);
            Instantiate(Obstacle, spawnPosition, Quaternion.identity);

            // Frissítjük a következõ akadály létrehozásának idõpontját
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

}
