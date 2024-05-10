using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
    public TMP_Text Counter;

    // Remove the duration variable as we don't need a limit
    // private int DurationLeft;

    //public GameObject WinScreen; // Assuming this is for demonstration

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateTimer());
    }

    // Update is called once per frame (not used here)
    void Update()
    {

    }

    IEnumerator UpdateTimer()
    {
        int currentTime = 0; // Start from 0

        while (true) // Infinite loop
        {
            Counter.text = $"{currentTime / 60:00} : {currentTime % 60:00}";

            currentTime++; // Increment counter

            yield return new WaitForSeconds(1f);
        }
    }

    // Remove the OnEnd function as the counter runs infinitely
    // void OnEnd()
    // {
    //     Time.timeScale = 0;
    //     WinScreen.SetActive(true);
    // }
}
