using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public GameObject Endscreen;

    public Animator TransitionAnimator;

    public GameObject Image;

    //public Animator transitionAnimator;

    private void Start()
    {
        Image.SetActive(true);

        StartCoroutine(First());

    }



    public void GameEnd()
    {

        Time.timeScale = 0;

        // itt meg meg kell allitani az idot

        Endscreen.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Image.SetActive(true);

        StartCoroutine(LoadLevel(1));
        //SceneManager.LoadScene(1);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1;

        Image.SetActive(true);

        StartCoroutine(LoadLevel(0));

        //SceneManager.LoadScene(0);

    }


    IEnumerator LoadLevel(int i)
    {
        TransitionAnimator.SetTrigger("End");

        yield return new WaitForSeconds(3);


        SceneManager.LoadSceneAsync(i);

        //yield return new WaitForEndOfFrame();

        //TransitionAnimator.SetTrigger("Start");

    }

    IEnumerator First()
    {
        yield return new WaitForSeconds(1);

        Image.SetActive(false);

    }






    }
