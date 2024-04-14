using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PlayerHealth : MonoBehaviour
{

    public int MaxHealth = 5; // A maxim�lis �leter�
    public int CurrentHealth = 5; // Jelenlegi �leter�

    //public AnimationClip[] MoodAnimations;
    public TMP_Text HealthText; // UI sz�veg a j�t�kos �leterej�nek megjelen�t�s�hez
    public GameObject ShowImage;
    public GameObject[] face;

    

    private Image ShowI;
    private TMP_Text text;


    public List<Image> image;

    private void Start()
    {

        foreach (var face in face){

            image.Add(face.GetComponent<Image>());
        }

        ShowI = ShowImage.GetComponent<Image>();

        text = HealthText.GetComponent<TMP_Text>();

        CurrentHealth = MaxHealth;
        UpdateHealthUI();
    }

void Update(){
MoodChanging();

}




    public void DecreaseHealth(int amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;

            Debug.Log("meghaltal");
            // A j�t�kos meghalt, �rhat itt tov�bbi k�dot, p�ld�ul a j�t�k �jraind�t�s�t vagy m�s tev�kenys�geket.
        }

        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (HealthText != null)
        {
            text.text = CurrentHealth.ToString();
        }
    }

    void MoodChanging(){

    ShowI = image[CurrentHealth-1];



    }



}
