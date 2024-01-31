using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    //public TextMeshProUGUI fuel1Text;
    //public TextMeshProUGUI fuel2Text;
    public Movement car1;
    public Movement car2;
    public bool hasItem;
    
    //items
    public bool hasGasCan;
    private GasCan gasCan;
    public bool hasTent;
    public GameObject tent;
    public bool hasBoost;
    public GameObject boostPad;
    public bool hasSpring;
    public GameObject springPad;
    
    public float time;
    public TextMeshProUGUI timerText;
    public Slider fuelMeter1;
    public Slider fuelMeter2;
    public float fuelAmount1;
    public float fuelAmount2;
    public int lives = 3;
    public TextMeshProUGUI livesText;
    public GameObject timer;
    public GameObject lifeMeter;

    // Start is called before the first frame update
    void Start()
    {
        GameModes.useTime = true;
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + time;
        gasCan = GetComponent<GasCan>();
        hasItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        //fuel1Text.text = "Fuel: " + Mathf.Round(car1.fuelLevel);
        //fuel2Text.text = "Fuel: " + Mathf.Round(car2.fuelLevel);

        if (hasTent)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Spawn tent");
                Instantiate(tent, car1.transform.position + new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10)), tent.transform.rotation);
                hasTent = false;
                hasItem = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Spawn tent");
                Instantiate(tent, car2.transform.position + new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10)), tent.transform.rotation);
                hasTent = false;
                hasItem = false;
            }
        }

        if (hasBoost)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Spawn boost pad");
                Instantiate(boostPad, car1.transform.position + new Vector3(Random.Range(-10, 10), -0.92f, Random.Range(-10, 10)), tent.transform.rotation);
                hasBoost = false;
                hasItem = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Spawn boost pad");
                Instantiate(boostPad, car2.transform.position + new Vector3(Random.Range(-10, 10), -0.92f, Random.Range(-10, 10)), tent.transform.rotation);
                hasBoost = false;
                hasItem = false;
            }
        }

        if (hasSpring)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Spawn spring pad");
                Instantiate(springPad, car1.transform.position + new Vector3(Random.Range(-10, 10), -0.92f, Random.Range(-10, 10)), tent.transform.rotation);
                hasSpring = false;
                hasItem = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Spawn spring pad");
                Instantiate(springPad, car2.transform.position + new Vector3(Random.Range(-10, 10), -0.92f, Random.Range(-10, 10)), tent.transform.rotation);
                hasSpring = false;
                hasItem = false;
            }
        }

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
        Loader.Load(Loader.Scene.GameEndMenu);
    }

}
