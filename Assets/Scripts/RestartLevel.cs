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
        if (Score.stage == 1)
        {
            Loader.Load(Loader.Scene.Test);
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
            Loader.Load(Loader.Scene.ConstructionCity);
        }
    }
}
