using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceButton : MonoBehaviour
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
        Loader.Load(Loader.Scene.Loading);
        Score.stage = 3;
    }
}
