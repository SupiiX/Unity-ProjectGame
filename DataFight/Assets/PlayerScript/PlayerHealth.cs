using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PlayerHealth : MonoBehaviour
{

    public int MaxHealth = 4; // A maxim lis  leter 
    public int CurrentHealth = 4; // Jelenlegi  leter 
    public TMP_Text HealthText;

    //public UnityEngine.UI.Image Heart;

    public GameObject Heart;
    private Animator animator;


    public Sprite[] FaceImage;


    private TMP_Text text;


    void Start()
    {
        animator = Heart.GetComponent<Animator>();

        text = HealthText.GetComponent<TMP_Text>();

        CurrentHealth = MaxHealth;
        UpdateHealthUI();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            DecreaseHealth(1);
        }
        else if(other.CompareTag("Obstacle"))
        {
            DecreaseHealth(1);

        }
    }



    public void DecreaseHealth(int amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;

            Debug.Log("meghaltal");
            
        }

        UpdateHealthUI();


     
    }

    void UpdateHealthUI()
    {
        if (HealthText != null)
        {
            text.text = CurrentHealth.ToString();
        }

        animator.SetInteger("ChangeHp", CurrentHealth);

        //Heart.sprite = FaceImage[CurrentHealth];      
    }

  



    }
