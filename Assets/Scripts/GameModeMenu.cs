using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameModeMenu : MonoBehaviour
{
    public Toggle gameMode1;
    public Toggle gameMode2;
    public Toggle gameMode3;
    public Toggle gameMode4;
    public Toggle gameMode5;
    public Toggle gameMode6;
    public Toggle gameMode7;
    public Toggle gameMode8;
    public Toggle gameMode9;
    public Toggle gameMode10;
    public Toggle gameMode11;
    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    public void MixUp(bool isToggleOn)
    {
        isToggleOn = gameMode1.isOn;
        if (isToggleOn)
        {
            GameModes.mixUp = true;
            Debug.Log("mix up");
        }
        else
        {
            GameModes.mixUp = false;
            Debug.Log("not mix up");
        }
    }

    public void PeculiarPassengers(bool isToggleOn)
    {
        isToggleOn = gameMode2.isOn;
        if (isToggleOn)
        { 
            GameModes.peculiarPassengers = true;
            Debug.Log("mix up");
        }
        else
        {
            GameModes.peculiarPassengers = false;
            Debug.Log("not mix up");
        }
    }

    public void RunningOnFumes(bool isToggleOn)
    {
        isToggleOn = gameMode3.isOn;
        if (isToggleOn)
        {
            GameModes.runningOnFumes = true;
        }
        else
        {
            GameModes.runningOnFumes = false;
        }
    }

    public void WornOutWheels(bool isToggleOn)
    {
        isToggleOn = gameMode4.isOn;
        if (isToggleOn)
        {
            GameModes.wornOutWheels = true;
        }
        else
        {
            GameModes.wornOutWheels = false;
        }
    }

    public void GasLeak(bool isToggleOn)
    {
        isToggleOn = gameMode5.isOn;
        if (isToggleOn)
        {
            GameModes.gasLeak = true;
        }
        else
        {
            GameModes.gasLeak = false;
        }
    }

    public void FragilePassengers(bool isToggleOn)
    {
        isToggleOn = gameMode6.isOn;
        if (isToggleOn)
        {
            GameModes.fragilePassengers = true;
        }
        else
        {
            GameModes.fragilePassengers = false;
        }
    }

    public void Turbo(bool isToggleOn)
    {
        isToggleOn = gameMode7.isOn;
        if (isToggleOn)
        {
            GameModes.turbo = true;
        }
        else
        {
            GameModes.turbo = false;
        }
    }

    public void SuperLaunch(bool isToggleOn)
    {
        isToggleOn = gameMode8.isOn;
        if (isToggleOn)
        {
            GameModes.superLaunch = true;
        }
        else
        {
            GameModes.superLaunch = false;
        }
    }

    public void StickyWheels(bool isToggleOn)
    {
        isToggleOn = gameMode9.isOn;
        if (isToggleOn)
        {
            GameModes.stickyWheels = true;
        }
        else
        {
            GameModes.stickyWheels = false;
        }
    }

    public void BigCars(bool isToggleOn)
    {
        isToggleOn = gameMode10.isOn;
        if (isToggleOn)
        {
            GameModes.bigCars = true;
        }
        else
        {
            GameModes.bigCars = false;
        }
    }

    public void Lobber(bool isToggleOn)
    {
        isToggleOn = gameMode11.isOn;
        if (isToggleOn)
        {
            GameModes.lobber = true;
        }
        else
        {
            GameModes.lobber = false;
        }
    }
}
