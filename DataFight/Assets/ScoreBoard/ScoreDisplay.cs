using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    public TMP_Text First;
    public TMP_Text FirstTime;
    public TMP_Text Second;
    public TMP_Text SecondTime;
    public TMP_Text Third;
    public TMP_Text ThirdTime;

    private void Start()
    {
        DisplayHighScores();
    }

    private void DisplayHighScores()
    {
        List<ScoreEntry> highScores = GetHighScores();

        if (highScores.Count > 0)
        {
            First.text = highScores[0].points.ToString();
            FirstTime.text = FormatTime(highScores[0].time);
        }
        else
        {
            First.text = "0";
            FirstTime.text = "00:00";
        }
        if (highScores.Count > 1)
        {
            Second.text = highScores[1].points.ToString();
            SecondTime.text = FormatTime(highScores[1].time);
        }
        else
        {
            Second.text = "0";
            SecondTime.text = "00:00";
        }
        if (highScores.Count > 2)
        {
            Third.text = highScores[2].points.ToString();
            ThirdTime.text = FormatTime(highScores[2].time);
        }
        else
        {
            Third.text = "0";
            ThirdTime.text = "00:00";
        }
    }

    private List<ScoreEntry> GetHighScores()
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

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetHighScores()
    {
        for (int i = 0; i < 3; i++)
        {
            PlayerPrefs.DeleteKey("HighScore" + i);
            PlayerPrefs.DeleteKey("HighScoreTime" + i);
        }
        PlayerPrefs.Save();
        DisplayHighScores(); // Frissítjük a megjelenített pontszámokat
    }
}
