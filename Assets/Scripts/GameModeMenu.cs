using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameModeMenu : MonoBehaviour
{
    private Toggle gameMode1;
    private Toggle gameMode2;
    private Toggle gameMode3;
    private Toggle gameMode4;
    private Toggle gameMode5;
    private Toggle gameMode6;
    private Toggle gameMode7;
    private Toggle gameMode8;
    private Toggle gameMode9;
    private Toggle gameMode10;
    private Toggle gameMode11;
    public void Start()
    {
        gameMode1 = GameObject.Find("MU").GetComponent<Toggle>();
        gameMode2 = GameObject.Find("PC").GetComponent<Toggle>();
        gameMode3 = GameObject.Find("ROF").GetComponent<Toggle>();
        gameMode4 = GameObject.Find("WOW").GetComponent<Toggle>();
        gameMode5 = GameObject.Find("GL").GetComponent<Toggle>();
        gameMode6 = GameObject.Find("FP").GetComponent<Toggle>();
        gameMode7 = GameObject.Find("T").GetComponent<Toggle>();
        gameMode8 = GameObject.Find("SL").GetComponent<Toggle>();
        gameMode9 = GameObject.Find("SW").GetComponent<Toggle>();
        gameMode10 = GameObject.Find("BC").GetComponent<Toggle>();
        gameMode11 = GameObject.Find("L").GetComponent<Toggle>();
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    public void MixUp(bool isToggleOn)
    {
        if (isToggleOn)
        {
            GameModes.mixUp = true;
        }
        else
        {
            GameModes.mixUp = false;
        }
        isToggleOn = gameMode1.isOn;
    }

    public void PeculiarPassengers(bool isToggleOn)
    {
        if (isToggleOn)
        { 
            GameModes.peculiarPassengers = true; 
        }
        else
        {
            GameModes.peculiarPassengers = false;
        }
        isToggleOn = gameMode2.isOn;
    }

    public void RunningOnFumes(bool isToggleOn)
    {
        if (isToggleOn)
        {
            GameModes.runningOnFumes = true;
        }
        else
        {
            GameModes.runningOnFumes = false;
        }
        isToggleOn = gameMode3.isOn;
    }

    public void WornOutWheels(bool isToggleOn)
    {
        if (isToggleOn)
        {
            GameModes.wornOutWheels = true;
        }
        else
        {
            GameModes.wornOutWheels = false;
        }
        isToggleOn = gameMode4.isOn;
    }

    public void GasLeak(bool isToggleOn)
    {
        if (isToggleOn)
        {
            GameModes.gasLeak = true;
        }
        else
        {
            GameModes.gasLeak = false;
        }
        isToggleOn = gameMode5.isOn;
    }

    public void FragilePassengers(bool isToggleOn)
    {
        if (isToggleOn)
        {
            GameModes.fragilePassengers = true;
        }
        else
        {
            GameModes.fragilePassengers = false;
        }
        isToggleOn = gameMode6.isOn;
    }

    public void Turbo(bool isToggleOn)
    {
        if (isToggleOn)
        {
            GameModes.turbo = true;
        }
        else
        {
            GameModes.turbo = false;
        }
        isToggleOn = gameMode7.isOn;
    }

    public void SuperLaunch(bool isToggleOn)
    {
        if (isToggleOn)
        {
            GameModes.superLaunch = true;
        }
        else
        {
            GameModes.superLaunch = false;
        }
        isToggleOn = gameMode8.isOn;
    }

    public void StickyWheels(bool isToggleOn)
    {
        if (isToggleOn)
        {
            GameModes.stickyWheels = true;
        }
        else
        {
            GameModes.stickyWheels = false;
        }
        isToggleOn = gameMode9.isOn;
    }

    public void BigCars(bool isToggleOn)
    {
        if (isToggleOn)
        {
            GameModes.bigCars = true;
        }
        else
        {
            GameModes.bigCars = false;
        }
        isToggleOn = gameMode10.isOn;
    }

    public void Lobber(bool isToggleOn)
    {
        if (isToggleOn)
        {
            GameModes.lobber = true;
        }
        else
        {
            GameModes.lobber = false;
        }
        isToggleOn = gameMode11.isOn;
    }
}
