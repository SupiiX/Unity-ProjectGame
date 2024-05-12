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
        
        // Kikapcsoljuk az enemy sprite-j�t
        GetComponent<SpriteRenderer>().enabled = false;

      //  rb.velocity = Vector2.zero;

        // Lej�tszuk a puffDust anim�ci�t
        puffAnimator.SetBool("DashDust", true);

        // V�runk egy kicsit, hogy lej�tssza az anim�ci�t
        StartCoroutine(DestroyAfterAnimation());
    }

    IEnumerator DestroyAfterAnimation()
    {
        // V�runk, am�g lej�tsz�dik a puffDust anim�ci�
        yield return new WaitForSeconds(0.5f);

        // Megsemmis�tj�k az enemyt
        Destroy(gameObject);
    }
}
