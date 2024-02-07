using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownButton : MonoBehaviour
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
        Loader.Load(Loader.Scene.TownScene);
        Score.stage = 1;
    }
}
