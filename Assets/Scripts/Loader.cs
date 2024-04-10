using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class Loader
{
    public enum Scene
    {
        MainMenu, LevelSelect, DesertScene, TownScene, Domenic, IcyLevel, GameEndMenu, CityLevel, VehicleSelect, Loading
    }
    public static void Load(Scene scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
    }
}
