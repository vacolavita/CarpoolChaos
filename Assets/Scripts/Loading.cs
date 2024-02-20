using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Loader.Load(Loader.Scene.MainMenu);
    }
}
