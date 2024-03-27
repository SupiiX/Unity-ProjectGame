using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage = 10;  // Lövedék sebzése
    public float lifeTime = 2f;  // Lövedék élettartama másodpercekben

    void Start()
    {
        // Automatikusan töröljük a lövedéket az élettartam lejárta után
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ellenõrizzük, hogy a lövedék ütközött-e valamivel, és ha igen, töröljük azt

        //Destroy(gameObject);


        // Ellenõrizzük, hogy az ütközött másik GameObject rendelkezik-e életerõ-csökkentõ komponenssel (EnemyHealth)

        //EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        //if (enemyHealth != null)
        //{
        //    // Átadjuk a sebzést az életerõ-csökkentõ függvénynek
        //    enemyHealth.TakeDamage(damage);

        //    Destroy(gameObject);
        //}
    }

}
