using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    public TextMeshProUGUI fuel1Text;
    public TextMeshProUGUI fuel2Text;
    public Movement car1;
    public Movement car2;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        fuel1Text.text = "Fuel: " + car1.fuelLevel;
        fuel2Text.text = "Fuel: " + car2.fuelLevel;
    }

    // Update is called once per frame
    void Update()
    {

        fuel1Text.text = "Fuel: " + Mathf.Round(car1.fuelLevel);
        fuel2Text.text = "Fuel: " + Mathf.Round(car2.fuelLevel);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    
}
