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
   // private int points;
    private float elapsedTime;
    private bool isGameRunning;

    private void Start()
    {
        Image.SetActive(true);
        StartCoroutine(First());

       // points = 0;
        elapsedTime = 0f;
        isGameRunning = true;
    }

    private void Update()
    {
        if (isGameRunning)
        {
            elapsedTime += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }

    }

    public void GameEnd()
    {

        Time.timeScale = 0;
        Endscreen.SetActive(true);
        isGameRunning = false;



        //ScoreManager scoreManager = GetComponent<ScoreManager>();
        //scoreManager.SaveHighScore(PP.POINTS, elapsedTime);
        // Debug.Log($"{scoreManager.scoreText.text}");

        ScoreManager.Instance.SaveHighScore(PP.POINTS, elapsedTime);


        ScoreCounter.text = ScoreManager.Instance.scoreText.text;

        //ScoreCounter.text = scoreManager.scoreText.text;
        FinalCounter.text = FormatTime(elapsedTime);

        //?

        //PP.Reset();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        Image.SetActive(true);
        // PP.POINTS = 0;
        PP.Reset();
        ScoreManager.Instance.currentScore = 0;
        ScoreManager.Instance.UpdateScoreText();
        TransitionAnimator.SetTrigger("End");
        StartCoroutine(LoadLevel(1));
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1;
        Image.SetActive(true);
        PP.POINTS = 0;
        ScoreManager.Instance.currentScore = 0;
        TransitionAnimator.SetTrigger("End");
        StartCoroutine(LoadLevel(0));
    }

    IEnumerator LoadLevel(int i)
    {
        
        Debug.Log("Animáció várakozás megkezdése.");

        //yield return new WaitForSeconds(1);

        yield return new WaitUntil(() => TransitionAnimator.GetCurrentAnimatorStateInfo(0).IsName("End") &&
                                   TransitionAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);

        Debug.Log("Animáció befejezõdött.");

        CleanMemory();

        Debug.Log("Scene váltás.");

        SceneManager.LoadScene(i);
    }

    IEnumerator First()
    {
        yield return new WaitForSeconds(1);
        Image.SetActive(false);
    }

    void CleanMemory()
    {
        System.GC.Collect();
        Resources.UnloadUnusedAssets();

        //Resources.
    }



    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
