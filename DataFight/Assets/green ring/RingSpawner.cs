using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawner : MonoBehaviour
{
    public GameObject spherePrefab; // A gömb prefab
    public Transform leftSpawnPoint; // Bal spawn pozíció
    public Transform rightSpawnPoint; // Jobb spawn pozíció
    public float spawnInterval = 3f; // Spawn idõköz (másodpercben)
    public float startTime = 60f; // Kezdõ idõ (másodpercben)

    private float elapsedTime = 0f; // Eltelt idõ

    void Update()
    {
        // Idõszámláló növelése
        elapsedTime += Time.deltaTime;

        // Ha az eltelt idõ nagyobb vagy egyenlõ a kezdõ idõvel, és az idõszámláló osztható a spawn idõközzel
        if (elapsedTime >= startTime && elapsedTime % spawnInterval <= Time.deltaTime)
        {
            Debug.Log("spawnba bemegyunk");

            // Spawnolás
            SpawnSphere();
        }
    }

    void SpawnSphere()
    {
        // Véletlenszerûen választunk irányt
        int direction = Random.Range(0, 2) == 0 ? -1 : 1;

        // Kiválasztjuk a megfelelõ spawn pozíciót
        Transform spawnPoint = direction == -1 ? leftSpawnPoint : rightSpawnPoint;

        // Létrehozzuk a gömböt a spawn pozíciónál
        GameObject sphere = Instantiate(spherePrefab, spawnPoint.position, Quaternion.identity);

        // Beállítjuk a gömb mozgás irányát a megfelelõ oldalra
       // sphere.GetComponent<RandomDirectionMovement>().direction = direction;
    }
}
