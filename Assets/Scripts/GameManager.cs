using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI fuel1Text;
    //public TextMeshProUGUI fuel2Text;
    public Movement car1;
    public Movement car2;
    public bool hasItem;
    public int score;
    
   
    
    public float time;
    public TextMeshProUGUI timerText;
    public Slider fuelMeter1;
    public Slider fuelMeter2;
    public float fuelAmount1;
    public float fuelAmount2;
    public float lives = 3;
    public TextMeshProUGUI livesText;
    public GameObject timer;
    public GameObject lifeMeter;
    public bool isGamePaused;
    public GameObject pauseScreen;
    public DustStorm dust;

    // Start is called before the first frame update
    void Start()
    {
        GameModes.useTime = true;
        score = 0;
        livesText.text = "Lives: " + Mathf.Round(lives);
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + time;
        hasItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        //fuel1Text.text = "Fuel: " + Mathf.Round(car1.fuelLevel);
        //fuel2Text.text = "Fuel: " + Mathf.Round(car2.fuelLevel);

        if (GameModes.useTime)
        {
            Timer(1);
            timer.SetActive(true);
            lifeMeter.SetActive(false);
        }

        if (GameModes.useLives)
        {
            lifeMeter.SetActive(true);
            timer.SetActive(false);
        }


        if (GameModes.useTime && time <= 0 || GameModes.useLives && lives <= 0)
        {
            EndGame();
        }
        GamePause();
        Score.score = score;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void Timer(float timeLeft)
    {
        time -= timeLeft * Time.deltaTime;

        float minutes = Mathf.FloorToInt(time / 60F);
        float seconds = Mathf.FloorToInt(time - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    public void EndGame()
    {
        Score.gameOver = true;
        Loader.Load(Loader.Scene.GameEndMenu);
    }

    public void LifeDrain(float livesToDrain)
    {
        lives += livesToDrain;
        livesText.text = "Lives: " + Mathf.Round(lives);
    }
    
    public void GamePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            isGamePaused = true;
            pauseScreen.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
        pauseScreen.SetActive(false);
    }

}
