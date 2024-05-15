using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawner : MonoBehaviour
{
    public GameObject spherePrefab; // A g�mb prefab
    public Transform leftSpawnPoint; // Bal spawn poz�ci�
    public Transform rightSpawnPoint; // Jobb spawn poz�ci�
    public float spawnInterval = 3f; // Spawn id�k�z (m�sodpercben)
    public float startTime = 60f; // Kezd� id� (m�sodpercben)

    private float elapsedTime = 0f; // Eltelt id�

    void Update()
    {
        // Id�sz�ml�l� n�vel�se
        elapsedTime += Time.deltaTime;

        // Ha az eltelt id� nagyobb vagy egyenl� a kezd� id�vel, �s az id�sz�ml�l� oszthat� a spawn id�k�zzel
        if (elapsedTime >= startTime && elapsedTime % spawnInterval <= Time.deltaTime)
        {
            Debug.Log("spawnba bemegyunk");

            // Spawnol�s
            SpawnSphere();
        }
    }

    void SpawnSphere()
    {
        // V�letlenszer�en v�lasztunk ir�nyt
        int direction = Random.Range(0, 2) == 0 ? -1 : 1;

        // Kiv�lasztjuk a megfelel� spawn poz�ci�t
        Transform spawnPoint = direction == -1 ? leftSpawnPoint : rightSpawnPoint;

        // L�trehozzuk a g�mb�t a spawn poz�ci�n�l
        GameObject sphere = Instantiate(spherePrefab, spawnPoint.position, Quaternion.identity);

        // Be�ll�tjuk a g�mb mozg�s ir�ny�t a megfelel� oldalra
       // sphere.GetComponent<RandomDirectionMovement>().direction = direction;
    }
}
