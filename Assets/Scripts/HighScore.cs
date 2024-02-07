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
        if (Score.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Score.score);
        }
    }

    void UpdateHighScoreText()
    {

        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore")}";
    }

    void UpdateScoreText()
    {
        scoreText.text = $"Score: {Score.score}";
    }
}
