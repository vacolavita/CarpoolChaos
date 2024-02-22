using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static splashManager;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI fuel1Text;
    //public TextMeshProUGUI fuel2Text;
    public Movement car1;
    public Movement car2;
    public bool hasItem;
    public int score;
    
   
    
    public TextMeshProUGUI timerText;
    public Slider fuelMeter1;
    public Slider fuelMeter2;
    public float fuelAmount1;
    public float fuelAmount2;
    public float lives = 3;
    public TextMeshProUGUI livesText;
    public GameObject lifeMeter;
    public bool isGamePaused;
    public GameObject pauseScreen;
    public DustStorm dust;

    bool oneMinute = false;
    public bool rush = false;

    // Start is called before the first frame update
    void Start()
    {
        GameModes.useTime = true;
        score = 0;
        livesText.text = "Lives: " + Mathf.Round(lives);
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + GameModes.time;
        hasItem = false;

        GameModes.time = GameModes.time + 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameModes.useTime)
        {
            Timer(1);
            lifeMeter.SetActive(false);
        }

        if (GameModes.useLives)
        {
            lifeMeter.SetActive(true);
        }


        if (GameModes.useTime && GameModes.time <= 1 || GameModes.useLives && lives <= 0)
        {
            EndGame();
        }
        GamePause();
        Score.score = score;

        if (GameModes.useTime && GameModes.time <= 61 && oneMinute == false) { 
            oneMinute = true;
            splashManager.splashes.Enqueue(new splashManager.splash(1, "One minute left!!!"));
        }
        if (GameModes.useTime && GameModes.time <= 91 && rush == false)
        {
            rush = true;
            splashManager.splashes.Enqueue(new splashManager.splash(1, "Rush!!!"));
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void Timer(float timeLeft)
    {
        GameModes.time -= timeLeft * Time.deltaTime;

        float minutes = Mathf.FloorToInt(GameModes.time / 60F);
        float seconds = Mathf.FloorToInt(GameModes.time - minutes * 60);
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
