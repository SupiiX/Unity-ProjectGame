using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingObstacleSpawner : MonoBehaviour
{
    public GameObject Obstacle; // Az akad�ly prefabja
    public Transform startPoint; // Kezd�pont, ahol az akad�lyok megjelennek
    public Transform endPoint; // V�gpont, ahol az akad�lyok v�get �rnek
    public float minSpawnInterval = 1f; // Minimum id�k�z az akad�lyok k�z�tt
    public float maxSpawnInterval = 7f; // Maximum id�k�z az akad�lyok k�z�tt
    public GameObject player;

    private float nextSpawnTime; // Az id�, amikor a k�vetkez� akad�lyt l�tre kell hozni

    void Start()
    {
        // Be�ll�tjuk az els� akad�ly l�trehoz�s�nak id�pontj�t
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    void Update()
    {
        // Ellen�rizz�k, hogy el�rkezett-e az id� a k�vetkez� akad�ly l�trehoz�s�ra
        if (Time.time >= nextSpawnTime)
        {
            
            //veletlen
            //Vector3 spawnPosition = new Vector3(Random.Range(startPoint.position.x, endPoint.position.x), startPoint.position.y, 0f);
                       

            // szandekos
            Vector3 spawnPosition = new Vector3(player.transform.position.x, startPoint.position.y, 0f);
            
            
            GameObject newObstacle = Instantiate(Obstacle, spawnPosition, Quaternion.identity);

            Debug.DrawLine(player.transform.position, newObstacle.transform.position, Color.red, 3f);

            // Friss�tj�k a k�vetkez� akad�ly l�trehoz�s�nak id�pontj�t
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

}
