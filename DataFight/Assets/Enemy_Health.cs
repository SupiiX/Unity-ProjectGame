using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{

    public int maxHealt = 10;
    [SerializeField] private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log($"{amount} adamage taken");
    }
}
