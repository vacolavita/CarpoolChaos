using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    public TextMeshProUGUI fuel1Text;
    public TextMeshProUGUI fuel2Text;
    public Movement car1;
    public Movement car2;
    public bool hasItem;
    
    //items
    public bool hasGasCan;
    private GasCan gasCan;
    public bool hasTent;
    public GameObject tent;
    
    public float time;
    public TextMeshProUGUI timerText;
    public Slider fuelMeter1;
    public Slider fuelMeter2;
    public float fuelAmount1;
    public float fuelAmount2;
    public int lives;
    public TextMeshProUGUI livesText;
    public bool useLives;
    public bool useTime;
    public GameObject timer;
    public GameObject lifeMeter;

    // Start is called before the first frame update
    void Start()
    {
        useTime = true;
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + time;
        gasCan = GetComponent<GasCan>();
    }

    // Update is called once per frame
    void Update()
    {
        fuel1Text.text = "Fuel: " + Mathf.Round(car1.fuelLevel);
        fuel2Text.text = "Fuel: " + Mathf.Round(car2.fuelLevel);

        if (hasGasCan)
        {
            gasCan.Gas();
        }

        if (hasTent)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Spawn tent");
                Instantiate(tent, car1.transform.position + new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10)), tent.transform.rotation);
                hasTent = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Spawn tent");
                Instantiate(tent, car2.transform.position + new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10)), tent.transform.rotation);
                hasTent = false;
            }
        }

        if (useTime)
        {
            Timer(1);
            timer.SetActive(true);
        }

        if (useLives)
        {
            useTime = false;
            lifeMeter.SetActive(true);
        }
        else
        {
            useTime = true;
            lifeMeter.SetActive(false);
        }


        if (useTime && time == 0 || useLives && lives == 0)
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
