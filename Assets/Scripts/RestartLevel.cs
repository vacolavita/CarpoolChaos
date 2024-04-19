using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RestartLevel : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Restart);
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void Restart()
    {
        Score.gameOver = false;
        Score.stage = 2;
        GameModes.time = 180;
        StaticGameManager.passengersOut = 0;
        if (Score.stage == 1)
        {
            Loader.Load(Loader.Scene.TownScene);
        }

        if (Score.stage == 2)
        {
            Loader.Load(Loader.Scene.DesertScene);
        }

        if (Score.stage == 3)
        {
            Loader.Load(Loader.Scene.IcyLevel);
        }

        if (Score.stage == 4)
        {
            Loader.Load(Loader.Scene.CityLevel);
        }
    }
}
