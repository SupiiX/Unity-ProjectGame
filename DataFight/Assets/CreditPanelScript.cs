using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditPanelScript : MonoBehaviour
{
    public GameObject creditPanel;

    // Megnyitja a Credit panelt
    public void ShowCredits()
    {
        creditPanel.SetActive(true);
    }

    // Bezárja a Credit panelt
    public void HideCredits()
    {
        creditPanel.SetActive(false);
    }
}
