using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilObstacle : MonoBehaviour
{
    public int health = 100;
    private int currentHealth; // Jelenlegi életerõ

    public GameObject PuffAnimation;

    private Animator PuffAnimator;
    private bool isDestroyed = false;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;

        PuffAnimator = PuffAnimation.GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        // Debug.Log("demage");

        currentHealth -= damage; // Életerõ csökkentése a kapott sebzés értékével

        // Ha az életerõ eléri vagy meghaladja a 0-t, akkor az akadályt megsemmisítjük
        if (currentHealth <= 0)
        {
            if (!isDestroyed)
            {
                StartCoroutine(DestroyObstacleWithDelay());
            }
        }
    }

    IEnumerator DestroyObstacleWithDelay()
    {
        isDestroyed = true;
        yield return new WaitForSeconds(0.35f);
        Destroy(gameObject);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDestroyed)
        {
            return; // Ha már megsemmisült az akadály, ne történjen semmi
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            if (!isDestroyed)
            {
                StartCoroutine(DestroyObstacleWithDelay());
            }
        }
        else if (other.CompareTag("Player"))
        {
            //Játékoshoz való ütközés esetén

            PlayerMove playerMove = other.GetComponent<PlayerMove>();

          
            if (!isDestroyed)
            {
                StartCoroutine(DestroyObstacleWithDelay(playerMove));
            }

           // GroundTrigger.SetActive(false);


        }

        PuffAnimator.SetBool("DashDust", true);


        StartCoroutine(ResetJumpDustTrigger()); 


       // StartCoroutine(ResetGroundTrigger());
    }


    IEnumerator DestroyObstacleWithDelay(PlayerMove playerMove)
    {
        isDestroyed = true;
        yield return new WaitForSeconds(0.35f);
        Destroy(gameObject);

        if (playerMove != null)
        {
            playerMove.isGrounded = true;
        }

    }



    IEnumerator ResetJumpDustTrigger()
    {
        yield return new WaitForSeconds(0.35f);
        PuffAnimator.SetBool("DashDust", false);
    }
}
