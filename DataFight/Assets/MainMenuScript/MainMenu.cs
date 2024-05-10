using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator TransitionAnimator;

    public GameObject Transition;

    private void Start()
    {
        Transition.SetActive(true);

        StartCoroutine(First());
    }

    public void PlayGame()
    {

        //SceneManager.LoadScene("MainScene");

        Transition.SetActive(true);
        StartCoroutine(LoadLevel(1));


    }

    public void QuitGame(){

        Application.Quit();

    }


    IEnumerator LoadLevel(int i)
    {
        TransitionAnimator.SetTrigger("End");

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(i);

        //yield return new WaitForEndOfFrame();

        //TransitionAnimator.SetTrigger("Start");

    }

    IEnumerator First()
    {
        yield return new WaitForSeconds(1);

        Transition.SetActive(false);

    }




}
