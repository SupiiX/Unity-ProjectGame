using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuHandler : MonoBehaviour
{
public GameObject PauseMenu;

    // Update is called once per frame
 private void Update() {

  if (Input.GetKey(KeyCode.Escape)){
    
        PauseMenu.SetActive(true);
        Time.timeScale = 0;


            Debug.Log("itt a gond ");


            //Input.GetButton("Fire2"
        }
    }
}
