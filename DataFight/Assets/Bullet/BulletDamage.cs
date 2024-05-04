using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage = 10;  // Lövedék sebzése
    public float lifeTime = 2f;  // Lövedék élettartama másodpercekben
    public float bulletdeadlifetime = 0.4f;

    private Animator animator;

    private bool hasCollided = false; // Változó, amely jelzi, hogy a lövedék ütközött-e már


    void Start()
    {
        animator = GetComponent<Animator>();

        
        // Automatikusan töröljük a lövedéket az élettartam lejárta után
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {

        if (hasCollided)
        {
            // Állítsuk meg a lövedék mozgását, ha ütközött
            Rigidbody2D bulletRb = GetComponent<Rigidbody2D>();
            bulletRb.velocity = Vector2.zero;

            animator.SetBool("BulletDead", true); // Animáció lejátszása

            //float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;

            Invoke("DestroyObject", bulletdeadlifetime);

            hasCollided= false;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");

        if (other.gameObject.CompareTag("Enemy"))
        {

            hasCollided = true; // Állítsuk be, hogy a lövedék ütközött
            if (other.gameObject.TryGetComponent<Enemy_Health>(out Enemy_Health health))
            {
                health.TakeDamage(damage);
                Debug.Log($"Succesful collision!");
            }

        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            CeilObstacle obstacle = other.GetComponent<CeilObstacle>();

            if (obstacle != null)
            {
                // Átadjuk az akadálynak a sebzést
                obstacle.TakeDamage(damage);

                // Megsemmisítjük a lövedéket
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
        // Elpusztítjuk az objektumot
        Destroy(gameObject);
    }



}


