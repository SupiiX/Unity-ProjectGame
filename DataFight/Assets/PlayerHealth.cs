using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PlayerHealth : MonoBehaviour
{

    public int MaxHealt = 100; // A maxim�lis �leter�
    public int jelenlegiElet = 50; // Jelenlegi �leter�

    public GameObject HealthText; // UI sz�veg a j�t�kos �leterej�nek megjelen�t�s�hez
    private TMP_Text text;


    private void Start()
    {
        text = HealthText.GetComponent<TMP_Text>();

        jelenlegiElet = MaxHealt;
        FrissitEletUI();
    }

    public void VeszitEletet(int mennyiseg)
    {
        jelenlegiElet -= mennyiseg;

        if (jelenlegiElet <= 0)
        {
            jelenlegiElet = 0;

            Debug.Log("meghaltal");
            // A j�t�kos meghalt, �rhat itt tov�bbi k�dot, p�ld�ul a j�t�k �jraind�t�s�t vagy m�s tev�kenys�geket.
        }

        FrissitEletUI();
    }

    void FrissitEletUI()
    {
        if (HealthText != null)
        {
            text.text = "�leter�: " + jelenlegiElet.ToString();
        }
    }
}
