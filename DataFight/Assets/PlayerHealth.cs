using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class PlayerHealth : MonoBehaviour
{

    public int MaxHealt = 100; // A maximális életerõ
    public int jelenlegiElet = 50; // Jelenlegi életerõ

    public GameObject HealthText; // UI szöveg a játékos életerejének megjelenítéséhez
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
            // A játékos meghalt, írhat itt további kódot, például a játék újraindítását vagy más tevékenységeket.
        }

        FrissitEletUI();
    }

    void FrissitEletUI()
    {
        if (HealthText != null)
        {
            text.text = "Életerõ: " + jelenlegiElet.ToString();
        }
    }
}
