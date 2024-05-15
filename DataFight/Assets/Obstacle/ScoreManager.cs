using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class PP
{
    public static int POINTS;
}


public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int currentScore;

    void Start()
    {
        currentScore = 0;
        UpdateScoreText();
    }

    public void AddPoints(int pointsToAdd)
    {
        currentScore += pointsToAdd;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = currentScore.ToString();
        }
    }

    private void Update()
    {

        if (scoreText.text != null)
        {
            scoreText.text = PP.POINTS.ToString();

        }

       




    }
}