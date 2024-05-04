using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage = 10;  // L�ved�k sebz�se
    public float lifeTime = 2f;  // L�ved�k �lettartama m�sodpercekben
    public float bulletdeadlifetime = 0.4f;

    private Animator animator;

    private bool hasCollided = false; // V�ltoz�, amely jelzi, hogy a l�ved�k �tk�z�tt-e m�r


    void Start()
    {
        animator = GetComponent<Animator>();

        
        // Automatikusan t�r�lj�k a l�ved�ket az �lettartam lej�rta ut�n
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {

        if (hasCollided)
        {
            // �ll�tsuk meg a l�ved�k mozg�s�t, ha �tk�z�tt
            Rigidbody2D bulletRb = GetComponent<Rigidbody2D>();
            bulletRb.velocity = Vector2.zero;

            animator.SetBool("BulletDead", true); // Anim�ci� lej�tsz�sa

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

            hasCollided = true; // �ll�tsuk be, hogy a l�ved�k �tk�z�tt
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


