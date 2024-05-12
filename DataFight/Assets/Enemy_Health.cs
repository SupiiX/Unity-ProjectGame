using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    public GameObject puffDustAnimation;
    private Animator puffAnimator;

   private Rigidbody2D rb;


    void Start()
    {
        currentHealth = maxHealth;
        puffAnimator = puffDustAnimation.GetComponent<Animator>();

       rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            rb.velocity = Vector2.zero;

            Die();
        }
        Debug.Log($"{amount} damage taken");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rb.velocity = Vector2.zero;


            Die();
        }
    }

    public void Die()
    {
        
        // Kikapcsoljuk az enemy sprite-ját
        GetComponent<SpriteRenderer>().enabled = false;

      //  rb.velocity = Vector2.zero;

        // Lejátszuk a puffDust animációt
        puffAnimator.SetBool("DashDust", true);

        // Várunk egy kicsit, hogy lejátssza az animációt
        StartCoroutine(DestroyAfterAnimation());
    }

    IEnumerator DestroyAfterAnimation()
    {
        // Várunk, amíg lejátszódik a puffDust animáció
        yield return new WaitForSeconds(0.5f);

        // Megsemmisítjük az enemyt
        Destroy(gameObject);
    }
}
