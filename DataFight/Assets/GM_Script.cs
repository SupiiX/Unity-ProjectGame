using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GM_Script : MonoBehaviour
{
    public TMP_Text scoreText;
    private int currentScore;

    void Start()
    {

        currentScore = int.Parse(scoreText.text);

        UpdateScoreText();
    }

    public void AddPoints(int pointsToAdd)
    {
        currentScore += pointsToAdd;

        Debug.Log("ez a gm script");

        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = currentScore.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
