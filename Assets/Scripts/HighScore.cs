using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        CheckHighScore();
        UpdateScoreText();
        UpdateHighScoreText();
    }

    // Update is called once per frame
    void CheckHighScore()
    {
        if (Score.stage == 1)
        {
            if (Score.score > PlayerPrefs.GetInt("HighScore1", 0))
            {
                PlayerPrefs.SetInt("HighScore1", Score.score);
            }
        }

        if (Score.stage == 2)
        {
            if (Score.score > PlayerPrefs.GetInt("HighScore2", 0))
            {
                PlayerPrefs.SetInt("HighScore2", Score.score);
            }
        }

        if (Score.stage == 3)
        {
            if (Score.score > PlayerPrefs.GetInt("HighScore3", 0))
            {
                PlayerPrefs.SetInt("HighScore3", Score.score);
            }
        }

        if (Score.stage == 4)
        {
            if (Score.score > PlayerPrefs.GetInt("HighScore4", 0))
            {
                PlayerPrefs.SetInt("HighScore4", Score.score);
            }
        }
    }

    void UpdateHighScoreText()
    {
        if (Score.stage == 1)
        {
            highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore1")}";
        }

        if (Score.stage == 2)
        {
            highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore2")}";
        }

        if (Score.stage == 3)
        {
            highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore3")}";
        }

        if (Score.stage == 4)
        {
            highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore4")}";
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = $"Score: {Score.score}";
    }
}
