using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityLevel : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(PlayGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayGame()
    {
        Score.gameOver = false;
        Loader.Load(Loader.Scene.CityLevel);
        Score.stage = 4;
        GameModes.time = 180;
        StaticGameManager.passengersOut = 0;
    }
}
