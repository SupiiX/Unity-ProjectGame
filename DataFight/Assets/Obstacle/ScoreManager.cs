using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int currentScore;

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
            scoreText.text =currentScore.ToString();
        }
    }
}
