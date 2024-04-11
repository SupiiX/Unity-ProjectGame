using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bulletPrefab;  // L�ved�k prefab
    public float bulletSpeed = 10f;  // L�ved�k sebess�ge
    public float fireRate = 0.5f;  // L�v�s gyakoris�ga m�sodpercben
    private float nextFireTime = 0f;  // K�vetkez� l�v�s id�pontja
    //public int damagePerShot = 10;  // L�ved�k sebz�se


    public GameObject BulletSpawnPoint;


    private bool FirstShoot = true;

    private Vector2 lastMoveDirection;  // Utols� ismert mozg�si ir�ny

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
            // L�v�s vez�rl�se
            //animator.SetBool("Shooting", true); // l�v�nk

            if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
            {

                // getbuttton

                Shoot();


            }
        }
        else
        {
           // animator.SetBool("Shooting", false); // Ha nem l�v�nk, akkor az anim�ci� bool �rt�k�t hamisra �ll�tjuk
        }

        // Mozg�si ir�ny friss�t�se
        UpdateLastMoveDirection();
    }

    void Shoot()
    {
        // Friss�tj�k a k�vetkez� l�v�s id�pontj�t a l�v�si gyakoris�g alapj�n
        nextFireTime = Time.time + 1f / fireRate;

        // L�trehozzuk a l�ved�ket �s be�ll�tjuk annak sebess�g�t a mozg�si ir�ny alapj�n
        GameObject bullet = Instantiate(bulletPrefab, BulletSpawnPoint.transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = lastMoveDirection.normalized * bulletSpeed;

        // Adjuk hozz� a l�ved�khez egy "Bullet" c�mk�t, hogy azonos�thassuk ellens�gekkel val� �tk�z�sn�l
        bullet.tag = "Bullet";

        // Adjuk hozz� az �leter�-cs�kkent� komponenst a l�ved�khez
        //bullet.AddComponent<BulletDamage>();
    }

    void UpdateLastMoveDirection()
    {
        // Friss�tj�k az utols� ismert mozg�si ir�nyt
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (FirstShoot)
        {
            lastMoveDirection = new Vector2(1f, 0f);
            FirstShoot = false;
        }

        // Ellen�rizz�k, hogy a j�t�kos mozog-e
        if (horizontalInput != 0f || verticalInput != 0f)
        {
            lastMoveDirection = new Vector2(horizontalInput, verticalInput);
        }
    }

}
