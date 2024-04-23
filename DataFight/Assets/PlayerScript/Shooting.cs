using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bulletPrefab;  // Lövedék prefab
    public float bulletSpeed = 10f;  // Lövedék sebessége
    public float fireRate = 0.5f;  // Lövés gyakorisága másodpercben
    private float nextFireTime = 0f;  // Következõ lövés idõpontja
    //public int damagePerShot = 10;  // Lövedék sebzése


    public GameObject BulletSpawnPoint;


    private bool FirstShoot = true;

    private Vector2 lastMoveDirection;  // Utolsó ismert mozgási irány

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            // Lövés vezérlése
            //animator.SetBool("Shooting", true); // lövünk

            if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
            {

                // getbuttton

                Shoot();


            }
        }
        else
        {
           // animator.SetBool("Shooting", false); // Ha nem lövünk, akkor az animáció bool értékét hamisra állítjuk
        }

        // Mozgási irány frissítése
        UpdateLastMoveDirection();
    }

    void Shoot()
    {
        // Frissítjük a következõ lövés idõpontját a lövési gyakoriság alapján
        nextFireTime = Time.time + 1f / fireRate;

        // Létrehozzuk a lövedéket és beállítjuk annak sebességét a mozgási irány alapján
        GameObject bullet = Instantiate(bulletPrefab, BulletSpawnPoint.transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = lastMoveDirection.normalized * bulletSpeed;

        // Adjuk hozzá a lövedékhez egy "Bullet" címkét, hogy azonosíthassuk ellenségekkel való ütközésnél
        bullet.tag = "Bullet";

        // Adjuk hozzá az életerõ-csökkentõ komponenst a lövedékhez
        //bullet.AddComponent<BulletDamage>();
    }

    void UpdateLastMoveDirection()
    {
        // Frissítjük az utolsó ismert mozgási irányt
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (FirstShoot)
        {
            lastMoveDirection = new Vector2(1f, 0f);
            FirstShoot = false;
        }

        // Ellenõrizzük, hogy a játékos mozog-e
        if (horizontalInput != 0f || verticalInput != 0f)
        {
            lastMoveDirection = new Vector2(horizontalInput, verticalInput);
        }
    }

}
