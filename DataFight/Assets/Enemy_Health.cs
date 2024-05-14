using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    public GameObject puffDustAnimation;
    private Animator puffAnimator;

    private Collider2D[] obstacleCollider;

    private Rigidbody2D rb;

    public bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        puffAnimator = puffDustAnimation.GetComponent<Animator>();

        obstacleCollider = GetComponents<Collider2D>();

        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
           // rb.velocity = Vector2.zero;

            Die();
        }
        //Debug.Log($"{amount} damage taken");
    }

    void OnTriggerEnter2D(Collider2D other)
    {

      //  PlayerMove playerMove = other.GetComponent<PlayerMove>();

      //  ResetPlayer(playerMove);

        if (other.CompareTag("Player"))
        {
            PlayerMove playerMove = other.gameObject.GetComponent<PlayerMove>();
                    
            //if (playerMove != null)
            //{
            //    playerMove.isGrounded = true;
            //}

            rb.velocity = Vector2.zero;

            Die();

            playerMove.isGrounded = true;

            Debug.Log($"{playerMove.isGrounded}");
        }
    }

    public void Die()
    {
        
        // Kikapcsoljuk az enemy sprite-ját
        GetComponent<SpriteRenderer>().enabled = false;

        // obstacleCollider.enabled = false;

        foreach (Collider2D col in obstacleCollider)
        {
            col.enabled = false;
        }

        //  rb.velocity = Vector2.zero;

        // Lejátszuk a puffDust animációt
        puffAnimator.SetBool("DashDust", true);

        isDead = true;

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

    private void ResetPlayer(PlayerMove playerMove)
    {
        Debug.Log("RESET");

        if (playerMove != null)
        {
            playerMove.isGrounded = true;
        }
    }

}
