using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilObstacle : MonoBehaviour
{

    public int health = 100;
    private int currentHealth; // Jelenlegi életerõ

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

  

    public void TakeDamage(int damage)
    {
        Debug.Log("demage");

        currentHealth -= damage; // Életerõ csökkentése a kapott sebzés értékével

        // Ha az életerõ eléri vagy meghaladja a 0-t, akkor az akadályt megsemmisítjük
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


       
    }





}
