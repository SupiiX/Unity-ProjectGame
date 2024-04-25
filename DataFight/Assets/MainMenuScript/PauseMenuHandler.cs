using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuHandler : MonoBehaviour
{
public GameObject PauseMenu;

    void Start()
    {
        
    }

    // Update is called once per frame
 private void Update() {

  if (Input.GetKeyUp(KeyCode.Z)){
    
        PauseMenu.SetActive(true);
        Time.timeScale = 0;

  }
}
}
