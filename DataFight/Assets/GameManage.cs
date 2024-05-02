using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public GameObject Endscreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameEnd()
    {

        Time.timeScale = 0;

        Endscreen.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(1);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }



}
