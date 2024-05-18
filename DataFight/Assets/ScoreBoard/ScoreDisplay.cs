using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text highScoreText;

    private void Start()
    {
        DisplayHighScores();
    }

    private void DisplayHighScores()
    {
        List<ScoreEntry> highScores = Score.Instance.GetHighScores();
        highScoreText.text = "Top Scores:\n";

        for (int i = 0; i < highScores.Count; i++)
        {
            highScoreText.text += $"{i + 1}. Points: {highScores[i].points}, Time: {highScores[i].time:F2} sec\n";
        }
    }
}
