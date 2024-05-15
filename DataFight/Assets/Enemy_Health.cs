using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Health : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    public GameObject puffDustAnimation;
    private Animator puffAnimator;

    private Collider2D[] obstacleCollider;

    private Rigidbody2D rb;

    public bool isDead = false;

    public bool DeadByPlayer = false;
       
    //public ScoreManager scoreManager;

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
             other.gameObject.GetComponent<PlayerHealth>().DecreaseHealth(1);

            PlayerMove playerMove = other.gameObject.GetComponent<PlayerMove>();

            //if (playerMove != null)
            //{
            //    playerMove.isGrounded = true;
            //}

            DeadByPlayer = true;

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


        //  Debug.Log($"{ScoreManager.currentScore.ToString()}");

        PP.POINTS += 1;

        Debug.Log($"{PP.POINTS}");


        //if (!DeadByPlayer && scoreManager != null)
        //{
         
            
        //     scoreManager.AddPoints(1); // Assuming score is incremented by 1 point
            

        //}



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
