using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilObstacle : MonoBehaviour
{

    public int health = 100;
    private int currentHealth; // Jelenlegi �leter�

    public GameObject PuffAnimation;

    private Animator PuffAnimator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;

        PuffAnimator = PuffAnimation.GetComponent<Animator>();
    }

  

    public void TakeDamage(int damage)
    {
       // Debug.Log("demage");

        currentHealth -= damage; // �leter� cs�kkent�se a kapott sebz�s �rt�k�vel

        // Ha az �leter� el�ri vagy meghaladja a 0-t, akkor az akad�lyt megsemmis�tj�k
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

   

        if (other.gameObject.CompareTag("Ground"))
        {
          

            Destroy(gameObject);

        }
        else if (other.CompareTag("Player"))
        {

            //Destroy(gameObject);

            Destroy(gameObject);
        }

        

        PuffAnimator.SetBool("DashDust", true);

        ResetJumpDustTrigger();
    }

    IEnumerator ResetJumpDustTrigger()
    {
        yield return new WaitForSeconds(0.1f);
        PuffAnimator.SetBool("DashDust", false);
    }




}
