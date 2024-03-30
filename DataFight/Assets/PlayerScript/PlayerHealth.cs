using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PlayerHealth : MonoBehaviour
{

    public int MaxHealth = 100; // A maximális életerõ
    public int ActualHealth = 50; // Jelenlegi életerõ

    public TMP_Text HealthText; // UI szöveg a játékos életerejének megjelenítéséhez
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
            // A játékos meghalt, írhat itt további kódot, például a játék újraindítását vagy más tevékenységeket.
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
