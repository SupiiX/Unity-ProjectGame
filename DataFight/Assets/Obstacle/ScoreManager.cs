using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class PP
{
    public static int POINTS;
    public static float TIME;

    public static void Reset()
    {
        POINTS = 0;
        TIME = 0;
    }

}

[System.Serializable]
public class ScoreEntry
{
    public int points;
    public float time;

    public ScoreEntry(int points, float time)
    {
        this.points = points;
        this.time = time;
    }
}



public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public TMP_Text scoreText;
    public int currentScore;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Ha már létezik egy példány, állítsd alaphelyzetbe az értékeket és frissítsd az UI-t
            currentScore = 0;
            UpdateScoreText();
        }
    }

    void Start()
    {
        currentScore = 0;
        UpdateScoreText();
    }

    public void AddPoints(int pointsToAdd)
    {
       
        Debug.Log($"point added --> {currentScore+1}");

        currentScore += pointsToAdd;
        PP.POINTS = currentScore;

        Debug.Log($"?? --> {PP.POINTS + 1}");
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = currentScore.ToString();
        }
    }

    public void SaveHighScore(int points, float time)
    {
        List<ScoreEntry> highScores = GetHighScores();
        highScores.Add(new ScoreEntry(points, time));
        highScores.Sort((x, y) => y.points.CompareTo(x.points)); // Sort by points descending

        // Keep only top 3
        if (highScores.Count > 3)
        {
            highScores = highScores.GetRange(0, 3);
        }

        // Save high scores
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, highScores[i].points);
            PlayerPrefs.SetFloat("HighScoreTime" + i, highScores[i].time);
        }
        PlayerPrefs.Save();
    }

    public List<ScoreEntry> GetHighScores()
    {
        List<ScoreEntry> highScores = new List<ScoreEntry>();
        for (int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.HasKey("HighScore" + i))
            {
                int points = PlayerPrefs.GetInt("HighScore" + i);
                float time = PlayerPrefs.GetFloat("HighScoreTime" + i);
                highScores.Add(new ScoreEntry(points, time));
            }
        }
        return highScores;
    }
}