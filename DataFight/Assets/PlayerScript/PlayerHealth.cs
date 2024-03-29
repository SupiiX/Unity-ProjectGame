using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PlayerHealth : MonoBehaviour
{

    public int MaxHealth = 100; // A maxim�lis �leter�
    public int ActualHealth = 50; // Jelenlegi �leter�

    public TMP_Text HealthText; // UI sz�veg a j�t�kos �leterej�nek megjelen�t�s�hez
    private TMP_Text text;


    private void Start()
    {
        text = HealthText.GetComponent<TMP_Text>();

        ActualHealth = MaxHealth;
        FrissitEletUI();
    }

    public void VeszitEletet(int mennyiseg)
    {
        ActualHealth -= mennyiseg;

        if (ActualHealth <= 0)
        {
            ActualHealth = 0;

            Debug.Log("meghaltal");
            // A j�t�kos meghalt, �rhat itt tov�bbi k�dot, p�ld�ul a j�t�k �jraind�t�s�t vagy m�s tev�kenys�geket.
        }

        FrissitEletUI();
    }

    void FrissitEletUI()
    {
        if (HealthText != null)
        {
            text.text = ActualHealth.ToString();
        }
    }
}
