using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
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
            Loader.Load(Loader.Scene.ConstructionCity);
        }


    }
}
