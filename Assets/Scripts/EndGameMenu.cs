using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            GameModes.useTime = true;
            GameModes.useLives = false;
        }

        if (val == 1)
        {
            GameModes.useTime = false;
            GameModes.useLives = true
                ;
        }
    }
}
