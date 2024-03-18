using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static splashManager;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public Movement car1;
    public Movement car2;
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
    public float countdown = 3;
    public AudioSource music;
    //public DustStorm dust;

    bool oneMinute = false;
    public bool rush = false;

    //public bool isOnFire;

    //private int fireMin = 0;
    //private int fireMax = 10;
    //public int fireState;
    //public ParticleSystem fire;

    public float check;
    //public GameObject waterBucket;
    public Vector3[] spawnPoints;
    int spawn;
    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        GameModes.useTime = true;
        score = 0;
        livesText.text = "Lives: " + Mathf.Round(lives);
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + GameModes.time;
        //fire.Stop();
        //GameModes.time = GameModes.time + 0;
        //StartCoroutine(Fire());
        music = GameObject.Find("Music Manager").GetComponent<AudioSource>();
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

        //if(fireState == 6)
        //{
        //    isOnFire = true;
        //}

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
        if (oneMinute) {
            music.pitch = 1.2f;
        }

        StartFire();
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void Timer(float timeLeft)
    {
        if (countdown <= 0)
        {
            GameModes.time -= timeLeft * Time.deltaTime;
        }
        else 
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0) {
                StaticGameManager.control = true;
                UI.SetActive(true);
            }
        }

        float minutes = Mathf.FloorToInt(GameModes.time / 60F);
        float seconds = Mathf.FloorToInt(GameModes.time - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    public void EndGame()
    {
        Score.gameOver = true;
        Loader.Load(Loader.Scene.GameEndMenu);
    }

    public void QuitGame()
    {

        Score.gameOver = true;
        Loader.Load(Loader.Scene.MainMenu);
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

    public IEnumerator Fire()
    {
        //while (!isOnFire)
        {
            //fireState = Random.Range(fireMin, fireMax);
            //if (fireState == 6)
            {
            //    break;
            }
            yield return new WaitForSeconds(check);
        }
    }

    public void StartFire()
    {
        //if (fireState == 6 && isOnFire)
        {
            spawn = Random.Range(0, spawnPoints.Length);
            StopCoroutine(Fire());
            //Instantiate(waterBucket);
            //waterBucket.transform.position = spawnPoints[spawn] + new Vector3(0, 1, 0);
            //fire.Play();
        }
    }

    public void StopFire()
    {
        //fire.Stop();
        StartCoroutine(Fire());
    }
}