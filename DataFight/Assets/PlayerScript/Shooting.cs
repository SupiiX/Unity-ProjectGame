using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Shooting : MonoBehaviour
{

    public GameObject bulletPrefab;  // L�ved�k prefab
    public float bulletSpeed = 10f;  // L�ved�k sebess�ge
    public float fireRate = 0.5f;  // L�v�s gyakoris�ga m�sodpercben
    private float nextFireTime = 0f;  // K�vetkez� l�v�s id�pontja
    //public int damagePerShot = 10;  // L�ved�k sebz�se


    public GameObject BulletSpawnPoint;
    public GameObject BulletSpawnPoint2;
    public GameObject BulletSpawnPoint3;
    public GameObject BulletSpawnPointLeft;
    public GameObject BulletSpawnPoint2Left;
    public GameObject BulletSpawnPoint3Left;


    //-----------------------------------------------



    private bool FirstShoot = true;

    private Vector2 lastMoveDirection;  // Utols� ismert mozg�si ir�ny

    private Vector2 BulletGO;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0f || vertical != 0f)
        {
            // lastMoveDirection = new Vector2(horizontalInput, verticalInput);
            lastMoveDirection = horizontal < 0 ? Vector2.left : Vector2.right;
        }
        else if (FirstShoot)
        {

            lastMoveDirection = Vector2.right;
            FirstShoot = false;
        }
        else
        {
            ///
        }

        if (Input.GetButton("Fire1"))
        {
            // L�v�s vez�rl�se
            //animator.SetBool("Shooting", true); // l�v�nk

            

            if (Time.time >= nextFireTime)
            {
                 
                // getbuttton

                Shoot();
                              
            }
        }
        else
        {
            //BulletSpawnPointAnimator1.SetBool("BulletSpawn", false);
            //BulletSpawnPointAnimator2.SetBool("BulletSpawn", false);
            //BulletSpawnPointAnimator3.SetBool("BulletSpawn", false);
            //BulletSpawnPointAnimator1Left.SetBool("BulletSpawn", false);
            //BulletSpawnPointAnimator2Left.SetBool("BulletSpawn", false);
            //BulletSpawnPointAnimator3Left.SetBool("BulletSpawn", false);

        }


        //UpdateLastMoveDirection();
    }

    void Shoot()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Friss�tj�k a k�vetkez� l�v�s id�pontj�t a l�v�si gyakoris�g alapj�n
        nextFireTime = Time.time + 1f / fireRate;
   
        GameObject bullet = bulletPrefab;


        if (horizontal == 0 && vertical == 0)
        {
           
            if (lastMoveDirection == Vector2.left)
            {
                bullet = Instantiate(bulletPrefab, BulletSpawnPointLeft.transform.position, Quaternion.identity);

                //SetActiveObject(BulletSpawnPointAnimator1Left);

                //BulletSpawnPointAnimator1Left.SetBool("BulletSpawn", true);

            }
            else
            {
                bullet = Instantiate(bulletPrefab, BulletSpawnPoint.transform.position, Quaternion.identity);

                //SetActiveObject(BulletSpawnPointAnimator1);

                //BulletSpawnPointAnimator1.SetBool("BulletSpawn", true);
            }

            BulletGO = lastMoveDirection;

            //BulletSpawnPointAnimator1.SetBool("BulletSpawn", AnimateLoop);
            // BulletSpawnPointAnimator1.SetTrigger("BulletSpawnTrigger");

        }
        // joystick jobbra van mozgatva
        else if (horizontal > 0 && vertical < 0.2 || horizontal < 0 && vertical < 0.2)
        {
            if (lastMoveDirection == Vector2.left)
            {
                bullet = Instantiate(bulletPrefab, BulletSpawnPointLeft.transform.position, Quaternion.identity);

                //SetActiveObject(BulletSpawnPointAnimator1Left);

               // BulletSpawnPointAnimator1Left.SetBool("BulletSpawn", true);
            }
            else
            {
                bullet = Instantiate(bulletPrefab, BulletSpawnPoint.transform.position, Quaternion.identity);

              //  SetActiveObject(BulletSpawnPointAnimator1);

              //  BulletSpawnPointAnimator1.SetBool("BulletSpawn", true);
            }

            BulletGO = lastMoveDirection;

        }
        //  joystick �tl�san felfel� van mozgatva
        else if (horizontal > 0.6 && vertical > 0.6 || horizontal < -0.6 && vertical > 0.6)
        {
            if (lastMoveDirection == Vector2.left)
            {
                bullet = Instantiate(bulletPrefab, BulletSpawnPoint2Left.transform.position, Quaternion.identity);

              //  SetActiveObject(BulletSpawnPointAnimator2Left);

              //  BulletSpawnPointAnimator2Left.SetBool("BulletSpawn", true);

                BulletGO =  new Vector2(-1, 1);
            }
            else
            {
                bullet = Instantiate(bulletPrefab, BulletSpawnPoint2.transform.position, Quaternion.identity);

               // SetActiveObject(BulletSpawnPointAnimator2);

              //  BulletSpawnPointAnimator2.SetBool("BulletSpawn", true);

                BulletGO = new Vector2(1, 1);
            }

            //bullet = Instantiate(bulletPrefab, BulletSpawnPoint2.transform.position, Quaternion.identity);
            //SetActiveObject(BulletSpawnPointAnimator2);

        }
        // joystick felfel� van mozgatva
        else if (vertical == 1 && horizontal < 0.4)
        {

            if (lastMoveDirection == Vector2.left)
            {
                bullet = Instantiate(bulletPrefab, BulletSpawnPoint3Left.transform.position, Quaternion.identity);

               // SetActiveObject(BulletSpawnPointAnimator3Left);

              //  BulletSpawnPointAnimator3Left.SetBool("BulletSpawn", true);

            }
            else
            {
                bullet = Instantiate(bulletPrefab, BulletSpawnPoint3.transform.position, Quaternion.identity);

              //  SetActiveObject(BulletSpawnPointAnimator3);

              //  BulletSpawnPointAnimator3.SetBool("BulletSpawn", true);

                BulletGO = new Vector2(0, 1);

            }


           // bullet = Instantiate(bulletPrefab, BulletSpawnPoint3.transform.position, Quaternion.identity);
           // SetActiveObject(BulletSpawnPointAnimator3);

        }

        SpriteRenderer spriteRenderer = bullet.GetComponent<SpriteRenderer>();

        

        if (BulletGO == Vector2.left)
        {
            spriteRenderer.flipX = true;
        }
        else if (BulletGO == new Vector2(0,1))
        {
            //bullet.transform.rotation = Quaternion.Euler(0, 0, 90);

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

        bulletRb.velocity = BulletGO.normalized * bulletSpeed;   //!!!!!!

        // Adjuk hozz� a l�ved�khez egy "Bullet" c�mk�t, hogy azonos�thassuk ellens�gekkel val� �tk�z�sn�l
        bullet.tag = "Bullet";

       // BulletSpawnPointAnimator1.SetBool("BulletSpawn", true);

        //BulletSpawnPointAnimator1.SetBool("BulletSpawn", false);
        // Adjuk hozz� az �leter�-cs�kkent� komponenst a l�ved�khez
        //bullet.AddComponent<BulletDamage>();

    }


    void SetActiveObject(Animator activeObject)
    {
        //object1.SetActive(false);
        //object2.SetActive(false);
        //object3.SetActive(false);

        //activeObject.SetActive(true);

        //BulletSpawnPointAnimator1.SetBool("BulletSpawn", false);
        //BulletSpawnPointAnimator2.SetBool("BulletSpawn", false);
        //BulletSpawnPointAnimator3.SetBool("BulletSpawn", false);
        //BulletSpawnPointAnimator1Left.SetBool("BulletSpawn", false);
        //BulletSpawnPointAnimator2Left.SetBool("BulletSpawn", false);
        //BulletSpawnPointAnimator3Left.SetBool("BulletSpawn", false);

        //activeObject.SetBool("BulletSpawn", true);

        //Debug.Log($"{activeObject.name} -");
    }


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

    //    // Ellen�rizz�k, hogy a j�t�kos mozog-e
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
