using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class Loader
{
    public enum Scene
    {
        MainMenu, LevelSelect, DesertScene, SquareOne, Domenic, IcyLevel, GameEndMenu, ConstructionCity, VehicleSelect, Loading
    }
    public static void Load(Scene scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
    }
}
