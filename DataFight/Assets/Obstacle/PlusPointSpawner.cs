using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusPointSpawner : MonoBehaviour
{

    public GameObject PlusPoint; // Első plusz pont prefabja
    public GameObject PlusPoint2; // Második plusz pont prefabja
    public Transform startPoint; // Kezdőpont
    public Transform endPoint; // Végpont
    public float minSpawnInterval = 1f; // Minimum időközösség
    public float maxSpawnInterval = 7f; // Maximum időközösség
    ///public GameObject player;

    // private Transform PlayerPosition;

    private float nextSpawnTime; // Következő akadály létrehozásának ideje

    void Start()
    {
        // PlayerPosition = player.GetComponent<Transform>();

        // Beállítjuk az első akadály létrehozásának időpontját
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {
        // Ellenőrizzük, hogy eljött-e az idő a következő akadály létrehozására
        if (Time.time >= nextSpawnTime)
        {

            // Véletlen pozíció
            Vector3 spawnPosition = new Vector3(Random.Range(startPoint.position.x, endPoint.position.x), startPoint.position.y, 0f);


            // Véletlen prefab kiválasztása
            int randomPrefabIndex = Random.Range(0, 2); // 0: PlusPoint, 1: PlusPoint2
            GameObject newObstacle = Instantiate(randomPrefabIndex == 0 ? PlusPoint : PlusPoint2, spawnPosition, Quaternion.identity);

            // Debug.DrawLine(player.transform.position, newObstacle.transform.position, Color.red, 3f);

            // Frissítjük a következő akadály létrehozásának időpontját
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }


}
