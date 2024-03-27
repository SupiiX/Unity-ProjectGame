using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage = 10;  // L�ved�k sebz�se
    public float lifeTime = 2f;  // L�ved�k �lettartama m�sodpercekben

    void Start()
    {
        // Automatikusan t�r�lj�k a l�ved�ket az �lettartam lej�rta ut�n
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Ellen�rizz�k, hogy a l�ved�k �tk�z�tt-e valamivel, �s ha igen, t�r�lj�k azt

        //Destroy(gameObject);


        // Ellen�rizz�k, hogy az �tk�z�tt m�sik GameObject rendelkezik-e �leter�-cs�kkent� komponenssel (EnemyHealth)

        //EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        //if (enemyHealth != null)
        //{
        //    // �tadjuk a sebz�st az �leter�-cs�kkent� f�ggv�nynek
        //    enemyHealth.TakeDamage(damage);

        //    Destroy(gameObject);
        //}
    }

}
