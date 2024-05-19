using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage = 10;  
    public float lifeTime = 2f;
    public float bulletdeadlifetime = 0.4f;

    private Animator animator;

    private bool hasCollided = false; 


    void Start()
    {
        animator = GetComponent<Animator>();

        
       
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {

        if (hasCollided)
        {
            
            Rigidbody2D bulletRb = GetComponent<Rigidbody2D>();
            bulletRb.velocity = Vector2.zero;

            animator.SetBool("BulletDead", true); 
            

            Invoke("DestroyObject", bulletdeadlifetime);

            hasCollided= false;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log("Trigger");

        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy_Health enemy_Health = other.GetComponent<Enemy_Health>();

            if (enemy_Health != null)
            {
                enemy_Health.TakeDamage(damage);

            }

            hasCollided = true; 
                                 
            
            // �ll�tsuk be, hogy a l�ved�k �tk�z�tt
            //if (other.gameObject.TryGetComponent<Enemy_Health>(out Enemy_Health health))
            //{
            //    health.TakeDamage(damage);
            //   // Debug.Log($"Succesful collision!");
            //}

        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            CeilObstacle obstacle = other.GetComponent<CeilObstacle>();

            if (obstacle != null)
            {
                // �tadjuk az akad�lynak a sebz�st
                obstacle.TakeDamage(damage);

                // Megsemmis�tj�k a l�ved�ket
            }

            hasCollided = true;
        }

    }

    /* void OnCollisionEnter2D(Collision2D collision)
    {
        hasCollided = true;
        
        if (collision.gameObject.TryGetComponent<Enemy_Health>(out Enemy_Health health))
        {
           health.TakeDamage(damage);
            Debug.Log($"Succesful collision!");
        }
       
    }*/


    void DestroyObject()
    {
        // Elpuszt�tjuk az objektumot
        Destroy(gameObject);
    }



}


