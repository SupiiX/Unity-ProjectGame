using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{

<<<<<<< Updated upstream
    public int maxHealt = 10;
    [SerializeField] private int currentHealth;
=======
    public int maxHealt = 100;
    private int currentHealth;
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

<<<<<<< Updated upstream
    
=======
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Bullet")
        {
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
            else { TakeDamage(100); }
        }
    }
>>>>>>> Stashed changes

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
<<<<<<< Updated upstream
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log($"{amount} adamage taken");
=======
>>>>>>> Stashed changes
    }
}
