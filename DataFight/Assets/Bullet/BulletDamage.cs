using System.Collections;
using System.Collections.Generic;
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

        if (other.gameObject.CompareTag("Enemy"))
        {

            hasCollided = true; // Állítsuk be, hogy a lövedék ütközött
        }
        

    }


    void DestroyObject()
    {
        // Elpusztítjuk az objektumot
        Destroy(gameObject);
    }



}


