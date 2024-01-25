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
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score;
        fuel1Text.text = "Fuel: " + car1.fuelLevel;
        fuel2Text.text = "Fuel: " + car2.fuelLevel;
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
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    
    public void ItemBoxChange()
    {
        
    }

    
}
