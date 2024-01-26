using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class Loader
{
    public enum Scene
    {
        LevelSelect, DesertLevel, TownLevel, Domenic
    }
    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
