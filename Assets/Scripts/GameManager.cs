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
    public bool hasGasCan;
    private GasCan gasCan;
    public float time;
    public TextMeshProUGUI timerText;
    public Slider fuelMeter1;
    public Slider fuelMeter2;
    public float fuelAmount1;
    public float fuelAmount2;
    // Start is called before the first frame update
    void Start()
    {
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
        Timer(1);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    
    public void ItemBoxChange()
    {
        
    }

    public void Timer(float timeLeft)
    {
        time -= timeLeft * Time.deltaTime;

        float minutes = Mathf.FloorToInt(time / 60F);
        float seconds = Mathf.FloorToInt(time - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

}
