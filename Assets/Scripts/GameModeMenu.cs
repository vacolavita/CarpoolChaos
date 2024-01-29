using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeMenu : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            GameModes.mixUp = false;
            GameModes.peculiarPassengers = false;
            GameModes.runningOnFumes = false;
            GameModes.wornOutWheels = false;
            GameModes.gasLeak = false;
            GameModes.fragilePassengers = false;
            GameModes.turbo = false;
            GameModes.superLaunch = false;
            GameModes.stickyWheels = false;
            GameModes.bigCars = false;
        }

        if (val == 1)
        {
            GameModes.mixUp = true;
            GameModes.peculiarPassengers = false;
            GameModes.runningOnFumes = false;
            GameModes.wornOutWheels = false;
            GameModes.gasLeak = false;
            GameModes.fragilePassengers = false;
            GameModes.turbo = false;
            GameModes.superLaunch = false;
            GameModes.stickyWheels = false;
            GameModes.bigCars = false;
        }

        if (val == 2)
        {
            GameModes.mixUp = false;
            GameModes.peculiarPassengers = true;
            GameModes.runningOnFumes = false;
            GameModes.wornOutWheels = false;
            GameModes.gasLeak = false;
            GameModes.fragilePassengers = false;
            GameModes.turbo = false;
            GameModes.superLaunch = false;
            GameModes.stickyWheels = false;
            GameModes.bigCars = false;
        }

        if (val == 3)
        {
            GameModes.mixUp = false;
            GameModes.peculiarPassengers = false;
            GameModes.runningOnFumes = true;
            GameModes.wornOutWheels = false;
            GameModes.gasLeak = false;
            GameModes.fragilePassengers = false;
            GameModes.turbo = false;
            GameModes.superLaunch = false;
            GameModes.stickyWheels = false;
            GameModes.bigCars = false;
        }

        if (val == 4)
        {
            GameModes.mixUp = false;
            GameModes.peculiarPassengers = false;
            GameModes.runningOnFumes = false;
            GameModes.wornOutWheels = true;
            GameModes.gasLeak = false;
            GameModes.fragilePassengers = false;
            GameModes.turbo = false;
            GameModes.superLaunch = false;
            GameModes.stickyWheels = false;
            GameModes.bigCars = false;
        }

        if (val == 5)
        {
            GameModes.mixUp = false;
            GameModes.peculiarPassengers = false;
            GameModes.runningOnFumes = false;
            GameModes.wornOutWheels = false;
            GameModes.gasLeak = true;
            GameModes.fragilePassengers = false;
            GameModes.turbo = false;
            GameModes.superLaunch = false;
            GameModes.stickyWheels = false;
            GameModes.bigCars = false;
        }

        if (val == 6)
        {
            GameModes.mixUp = false;
            GameModes.peculiarPassengers = false;
            GameModes.runningOnFumes = false;
            GameModes.wornOutWheels = false;
            GameModes.gasLeak = false;
            GameModes.fragilePassengers = true;
            GameModes.turbo = false;
            GameModes.superLaunch = false;
            GameModes.stickyWheels = false;
            GameModes.bigCars = false;
        }

        if (val == 7)
        {
            GameModes.mixUp = false;
            GameModes.peculiarPassengers = false;
            GameModes.runningOnFumes = false;
            GameModes.wornOutWheels = false;
            GameModes.gasLeak = false;
            GameModes.fragilePassengers = false;
            GameModes.turbo = true;
            GameModes.superLaunch = false;
            GameModes.stickyWheels = false;
            GameModes.bigCars = false;
        }

        if (val == 8)
        {
            GameModes.mixUp = false;
            GameModes.peculiarPassengers = false;
            GameModes.runningOnFumes = false;
            GameModes.wornOutWheels = false;
            GameModes.gasLeak = false;
            GameModes.fragilePassengers = false;
            GameModes.turbo = false;
            GameModes.superLaunch = true;
            GameModes.stickyWheels = false;
            GameModes.bigCars = false;
        }

        if (val == 9)
        {
            GameModes.mixUp = false;
            GameModes.peculiarPassengers = false;
            GameModes.runningOnFumes = false;
            GameModes.wornOutWheels = false;
            GameModes.gasLeak = false;
            GameModes.fragilePassengers = false;
            GameModes.turbo = false;
            GameModes.superLaunch = false;
            GameModes.stickyWheels = true;
            GameModes.bigCars = false;
        }

        if (val == 10)
        {
            GameModes.mixUp = false;
            GameModes.peculiarPassengers = false;
            GameModes.runningOnFumes = false;
            GameModes.wornOutWheels = false;
            GameModes.gasLeak = false;
            GameModes.fragilePassengers = false;
            GameModes.turbo = false;
            GameModes.superLaunch = false;
            GameModes.stickyWheels = false;
            GameModes.bigCars = true;
        }
    }
}
