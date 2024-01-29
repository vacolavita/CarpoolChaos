using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class Loader
{
    public enum Scene
    {
        MainMenu, LevelSelect, DesertScene, TownScene, Domenic, IcyLevel, GameEndMenu, ConstructionCity
    }
    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
