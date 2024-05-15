using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public GameObject Endscreen;

    public Animator TransitionAnimator;

    public GameObject Image;

    public GameObject PauseMenu;

    public TMP_Text ScoreCounter;

    public TMP_Text FinalCounter;

    //public Animator transitionAnimator;

    private void Start()
    {

        Image.SetActive(true);

        StartCoroutine(First());

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //GetComponent<PauseMenu>().Pause();

            Time.timeScale = 0;

            PauseMenu.SetActive(true);

        }
    }


    public void GameEnd()
    {

        Time.timeScale = 0;

        // itt meg meg kell allitani az idot
                 
        Endscreen.SetActive(true);

        Debug.Log($"{GetComponent<ScoreManager>().scoreText.text}");

        ScoreCounter.text = GetComponent<ScoreManager>().scoreText.text;
        FinalCounter.text = GetComponent<CounterScript>().Counter.text;

    }

    public void Restart()
    {
        Time.timeScale = 1;
        Image.SetActive(true);

        PP.POINTS = 0;

        TransitionAnimator.SetTrigger("End");

        StartCoroutine(LoadLevel(1));
        //SceneManager.LoadScene(1);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1;
        Image.SetActive(true);

        PP.POINTS = 0;

        TransitionAnimator.SetTrigger("End");

        StartCoroutine(LoadLevel(0));

       // SceneManager.LoadScene(0);

    }


    IEnumerator LoadLevel(int i)
    {
        //TransitionAnimator.SetTrigger("End");

        CleanMemory();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(i);

        //yield return new WaitForEndOfFrame();

        //TransitionAnimator.SetTrigger("Start");

    }

    IEnumerator First()
    {
        yield return new WaitForSeconds(1);

        Image.SetActive(false);

    }

    void CleanMemory()
    {
        // Meghívjuk a garbage collector tisztító metódusát
        System.GC.Collect();
        // Megtisztítjuk a nem használt erõforrásokat
        Resources.UnloadUnusedAssets();
    }




}
