using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Shooting : MonoBehaviour
{

    public GameObject bulletPrefab;  // Lövedék prefab
    public float bulletSpeed = 10f;  // Lövedék sebessége
    public float fireRate = 0.5f;  // Lövés gyakorisága másodpercben
    private float nextFireTime = 0f;  // Következõ lövés idõpontja
    //public int damagePerShot = 10;  // Lövedék sebzése


    public GameObject BulletSpawnPoint;
    public GameObject BulletSpawnPoint2;
    public GameObject BulletSpawnPoint3;

    private Animator BulletSpawnPointAnimator1;
    private Animator BulletSpawnPointAnimator2;
    private Animator BulletSpawnPointAnimator3;

    private bool FirstShoot = true;

    private Vector2 lastMoveDirection;  // Utolsó ismert mozgási irány
       
    // Start is called before the first frame update
    void Start()
    {
       
        BulletSpawnPointAnimator1 = BulletSpawnPoint.GetComponent<Animator>();
        BulletSpawnPointAnimator2 = BulletSpawnPoint2.GetComponent<Animator>();
        BulletSpawnPointAnimator3 = BulletSpawnPoint3.GetComponent<Animator>();

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
            BulletSpawnPointAnimator1.SetBool("BulletSpawn", false);
            BulletSpawnPointAnimator2.SetBool("BulletSpawn", false);
            BulletSpawnPointAnimator3.SetBool("BulletSpawn", false);
        }

       
        UpdateLastMoveDirection();
    }

    void Shoot()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Frissítjük a következõ lövés idõpontját a lövési gyakoriság alapján
        nextFireTime = Time.time + 1f / fireRate;
   
        GameObject bullet = bulletPrefab;


        if (horizontal == 0 && vertical == 0)
        {
             bullet = Instantiate(bulletPrefab, BulletSpawnPoint.transform.position, Quaternion.identity);

            //BulletSpawnPointAnimator1.SetBool("BulletSpawn", AnimateLoop);

            SetActiveObject(BulletSpawnPointAnimator1);
           
           // BulletSpawnPointAnimator1.SetTrigger("BulletSpawnTrigger");

        }
        // joystick jobbra van mozgatva
        else if (horizontal > 0 && vertical < 0.2 || horizontal < 0 && vertical < 0.2)
        {
             bullet = Instantiate(bulletPrefab, BulletSpawnPoint.transform.position, Quaternion.identity);

            //BulletSpawnPointAnimator1.SetBool("BulletSpawn", AnimateLoop);
            SetActiveObject(BulletSpawnPointAnimator1);
        }
        //  joystick átlósan felfelé van mozgatva
        else if (horizontal > 0.6 && vertical > 0.6 || horizontal < -0.6 && vertical > 0.6)
        {
             bullet = Instantiate(bulletPrefab, BulletSpawnPoint2.transform.position, Quaternion.identity);

            //BulletSpawnPointAnimator2.SetBool("BulletSpawn", AnimateLoop);
            SetActiveObject(BulletSpawnPointAnimator2);
        }
        // joystick felfelé van mozgatva
        else if (vertical == 1 && horizontal < 0.4)
        {
        
            bullet = Instantiate(bulletPrefab, BulletSpawnPoint3.transform.position, Quaternion.identity);

            //BulletSpawnPointAnimator3.SetBool("BulletSpawn", AnimateLoop);
            SetActiveObject(BulletSpawnPointAnimator3);

        }

        SpriteRenderer spriteRenderer = bullet.GetComponent<SpriteRenderer>();

        

        if (lastMoveDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (vertical == 1)
        {
            bullet.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            spriteRenderer.flipX= false;
        }



        //**
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        bulletRb.velocity = lastMoveDirection.normalized * bulletSpeed;

        // Adjuk hozzá a lövedékhez egy "Bullet" címkét, hogy azonosíthassuk ellenségekkel való ütközésnél
        bullet.tag = "Bullet";

        //BulletSpawnPointAnimator1.SetBool("BulletSpawn", false);
        // Adjuk hozzá az életerõ-csökkentõ komponenst a lövedékhez
        //bullet.AddComponent<BulletDamage>();
    }


    void SetActiveObject(Animator activeObject)
    {
        //object1.SetActive(false);
        //object2.SetActive(false);
        //object3.SetActive(false);

        //activeObject.SetActive(true);

        BulletSpawnPointAnimator1.SetBool("BulletSpawn", false);
        BulletSpawnPointAnimator2.SetBool("BulletSpawn", false);
        BulletSpawnPointAnimator3.SetBool("BulletSpawn", false);

        activeObject.SetBool("BulletSpawn", true);


    }


    void UpdateLastMoveDirection()
    {
        
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
        else
        {
            if (lastMoveDirection.x < 0)
            {
                lastMoveDirection = new Vector2(-1f, 0f);

            }
            else
            {
                lastMoveDirection = new Vector2(1f, 0f);
           }
            

        }
    }

}
