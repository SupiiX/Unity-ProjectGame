using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
public TMP_Text Counter;

public int  Duration;

private int DurationLeft;


public GameObject WinScreen;

    // Start is called before the first frame update
    void Start()
    {
        Being(Duration);

    }

    // Update is called once per frame
    void Update(){

    }


void Being (int Second){

DurationLeft = Second;

StartCoroutine(UpdateTimer());

}


IEnumerator UpdateTimer(){


    while(DurationLeft >= 0){

        Counter.text = $"{DurationLeft / 60:00} : {DurationLeft % 60:00}";

        DurationLeft--;

        yield return new WaitForSeconds(1f);

    }
OnEnd();

}

void OnEnd(){


        Time.timeScale = 0;

        WinScreen.SetActive(true);
    

}





}


