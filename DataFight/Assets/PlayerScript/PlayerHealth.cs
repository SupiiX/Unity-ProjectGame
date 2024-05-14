using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    public GameManage GManager;

    public Sprite[] FaceImage;

    //public SpriteRenderer renderer;

    

    private TMP_Text text;
    
    //[Header ("IFrames")]
    //[SerializeField] float duration = 1f;
    //[SerializeField] int numberOfFlashes = 3;
    


    void Start()
    {
        animator = Heart.GetComponent<Animator>();

        text = HealthText.GetComponent<TMP_Text>();

      //  renderer = GetComponent<SpriteRenderer>();

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
        else if (other.CompareTag("Obstacle"))
        {
            DecreaseHealth(1);

        }
    }

    //IEnumerator IFrame()
    //{
    //    //Physics2D.IgnoreLayerCollision(ide a player ayer száma kell,ide az enemy layer száma kell,true);
    //   for (int i = 0; i < numberOfFlashes; i++)
    //    {
    //        renderer.color = new Color(1, 0, 0, 0.5f);
    //        yield return new WaitForSeconds(duration/(numberOfFlashes*2));
    //        renderer.color = Color.white;
    //        yield return new WaitForSeconds(duration / (numberOfFlashes * 2));
    //    }
    //    //Physics2D.IgnoreLayerCollision(ide a player ayer száma kell,ide az enemy layer száma kell,false);

    //}



    public void DecreaseHealth(int amount)
    {
       CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;

            GManager.GameEnd();
            
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
