using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Shooting : MonoBehaviour
{

    public GameObject bulletPrefab;  // Lövedék prefab
    public float bulletSpeed = 10f;  // Lövedék sebessége
    public float fireRate = 0.5f;  // Lövés gyakorisága másodpercben
    private float nextFireTime = 0f;  // Következõ lövés idõpontja
   

    public GameObject BulletSpawnPoint;
    public GameObject BulletSpawnPoint2;
    public GameObject BulletSpawnPoint3;
    public GameObject BulletSpawnPointLeft;
    public GameObject BulletSpawnPoint2Left;
    public GameObject BulletSpawnPoint3Left;



    //-----------------------------------------------

    private bool FirstShoot = true;
    private Vector2 lastMoveDirection;  // Utolsó ismert mozgási irány
    private Vector2 BulletGO;

    private float Horizontal;
    private float Vertical;

    private bool FaceChanged = false;

    void Start()
    {
    

    }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");


        if (Horizontal < 0) // Balra mozgás esetén
        {
            //spriteRenderer.flipX = true; // Tükrözve
            FaceChanged = true;
        }
        else if (Horizontal > 0) // Jobbra mozgás esetén
        {
            //   spriteRenderer.flipX = false; // Normál
            FaceChanged = false;
        }
        // Ha a karakter nem mozog, de az elõzõ mozgás irányában volt az arc
        else if (FaceChanged == true)
        {
            //spriteRenderer.flipX = true; // Tükrözve marad
        }


        if (Horizontal != 0f || Vertical != 0f)
        {
            // lastMoveDirection = new Vector2(horizontalInput, verticalInput);
            lastMoveDirection = Horizontal < 0 ? Vector2.left : Vector2.right;
        }
        else if (FirstShoot)
        {

            lastMoveDirection = Vector2.right;
            FirstShoot = false;
        }
       

        if (Input.GetButton("Fire1"))
        {
                      
            if (Time.time >= nextFireTime)
            {       

                Shoot();                 
            }
        }

    }

    void Shoot()
    {
        

        // Frissítjük a következõ lövés idõpontját a lövési gyakoriság alapján
        nextFireTime = Time.time + 1f / fireRate;
   
        GameObject bullet = bulletPrefab;


        if (Horizontal == 0 && Vertical == 0)
        {
           
            if (FaceChanged)
            {
                bullet = Instantiate(bulletPrefab, BulletSpawnPointLeft.transform.position, Quaternion.identity);

                BulletGO = Vector2.left;

            }
            else
            {
                bullet = Instantiate(bulletPrefab, BulletSpawnPoint.transform.position, Quaternion.identity);

                BulletGO = Vector2.right;

            }         
                     
         }

        // joystick jobbra van mozgatva
        else if (Horizontal > 0 && Vertical < 0.2 || Horizontal < 0 && Vertical < 0.2)
        {
            if (FaceChanged)
            {
                bullet = Instantiate(bulletPrefab, BulletSpawnPointLeft.transform.position, Quaternion.identity);

                BulletGO = Vector2.left;

            }
            else
            {
                bullet = Instantiate(bulletPrefab, BulletSpawnPoint.transform.position, Quaternion.identity);

                BulletGO = Vector2.right;

            }
                            

        }
        //  joystick átlósan felfelé van mozgatva
        else if (Horizontal > 0.6 && Vertical > 0.6 || Horizontal < -0.6 && Vertical > 0.6)
        {
            if (FaceChanged)
            {
                bullet = Instantiate(bulletPrefab, BulletSpawnPoint2Left.transform.position, Quaternion.identity);

                BulletGO =  new Vector2(-1, 1);
            }
            else
            {
                bullet = Instantiate(bulletPrefab, BulletSpawnPoint2.transform.position, Quaternion.identity);

                BulletGO = new Vector2(1, 1);
            }

        }
        // joystick felfelé van mozgatva
        else if (Vertical == 1 && Horizontal < 0.4)
        {

            if (FaceChanged)
            {
                bullet = Instantiate(bulletPrefab, BulletSpawnPoint3Left.transform.position, Quaternion.identity);

                
            }
            else
            {
                bullet = Instantiate(bulletPrefab, BulletSpawnPoint3.transform.position, Quaternion.identity);
                            

            }
            BulletGO = new Vector2(0, 1);

            // bullet = Instantiate(bulletPrefab, BulletSpawnPoint3.transform.position, Quaternion.identity);

        }

        SpriteRenderer spriteRenderer = bullet.GetComponent<SpriteRenderer>();
               

        if (BulletGO == Vector2.left)
        {
            spriteRenderer.flipX = true;
        }
        else if (BulletGO == new Vector2(0,1))
        {
            bullet.transform.Rotate(0, 0, 90);
        }
        else if (BulletGO == new Vector2(1,1))
        {
            bullet.transform.Rotate(0, 0, 45);
        }
        else if (BulletGO == new Vector2(-1, 1))
        {
            bullet.transform.Rotate(0, 0, 135);
        }
        else
        {
            spriteRenderer.flipX= false;
        }

        //**
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        bulletRb.velocity = BulletGO.normalized * bulletSpeed;  

        bullet.tag = "Bullet";
 
    }


    //void SetActiveObject(Animator activeObject)
    //{
    //    object1.SetActive(false);
    //    object2.SetActive(false);
    //    object3.SetActive(false);

    //    activeObject.SetActive(true);

    //    BulletSpawnPointAnimator1.SetBool("BulletSpawn", false);
    //    BulletSpawnPointAnimator2.SetBool("BulletSpawn", false);
    //    BulletSpawnPointAnimator3.SetBool("BulletSpawn", false);
    //    BulletSpawnPointAnimator1Left.SetBool("BulletSpawn", false);
    //    BulletSpawnPointAnimator2Left.SetBool("BulletSpawn", false);
    //    BulletSpawnPointAnimator3Left.SetBool("BulletSpawn", false);

    //    activeObject.SetBool("BulletSpawn", true);

    //    Debug.Log($"{activeObject.name} -");
    //}


    //void UpdateLastMoveDirection()
    //{
        
    //    float horizontalInput = Input.GetAxisRaw("Horizontal");
    //    float verticalInput = Input.GetAxisRaw("Vertical");

    //    if (FirstShoot)
    //    {
    //     //   Vector2 vector2 = new Vector2(1f, 0f);
            
    //        lastMoveDirection = Vector2.right;
    //        FirstShoot = false;
    //    }

    //    // Ellenõrizzük, hogy a játékos mozog-e
    //    if (horizontalInput != 0f || verticalInput != 0f)
    //    {
    //        lastMoveDirection = new Vector2(horizontalInput, verticalInput);
    //    }
    //    else
    //    {
    //        if (lastMoveDirection.x < 0)
    //        {
    //            lastMoveDirection = new Vector2(-1f, 0f);

    //        }
    //        else
    //        {
    //            lastMoveDirection = new Vector2(1f, 0f);
    //       }
            

    //    }
    //}

}
