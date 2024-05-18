using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;

    private List<ScoreEntry> highScores = new List<ScoreEntry>();
    private const int MaxHighScores = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighScores();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points, float time)
    {
        ScoreEntry newScore = new ScoreEntry(points, time);
        highScores.Add(newScore);
        highScores.Sort((a, b) => b.points.CompareTo(a.points)); // Sort by points in descending order

        if (highScores.Count > MaxHighScores)
        {
            highScores.RemoveAt(highScores.Count - 1); // Remove the lowest score if we have more than MaxHighScores
        }

        SaveHighScores();
    }

    public List<ScoreEntry> GetHighScores()
    {
        return new List<ScoreEntry>(highScores);
    }

    private void SaveHighScores()
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetInt("HighScorePoints" + i, highScores[i].points);
            PlayerPrefs.SetFloat("HighScoreTime" + i, highScores[i].time);
        }
    }

    private void LoadHighScores()
    {
        highScores.Clear();

        for (int i = 0; i < MaxHighScores; i++)
        {
            if (PlayerPrefs.HasKey("HighScorePoints" + i))
            {
                int points = PlayerPrefs.GetInt("HighScorePoints" + i);
                float time = PlayerPrefs.GetFloat("HighScoreTime" + i);
                highScores.Add(new ScoreEntry(points, time));
            }
        }
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
