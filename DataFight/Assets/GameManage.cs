using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public GameObject Endscreen;

    public Animator transitionAnimator;



    public void GameEnd()
    {

        Time.timeScale = 0;

        Endscreen.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(1);

        //LoadLevel(1);

    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);

        //LoadLevel(0);

    }

    IEnumerator LoadLevel(int i)
    {

        transitionAnimator.SetTrigger("End");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(i);

        transitionAnimator.SetTrigger("Start");


    }



}
