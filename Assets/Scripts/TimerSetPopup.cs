using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSetPopup : MonoBehaviour
{
    public GameObject timerSet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameModes.useTime)
        {
            timerSet.SetActive(true);
        }
    }
}
