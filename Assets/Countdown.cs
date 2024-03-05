using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Countdown : MonoBehaviour
{
    public Timer timer;
    public TextMeshProUGUI tmp;
    void Start()
    {
        timer = GetComponent<Timer>();
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.reachedMilestone(0)) {
            tmp.SetText("3...");
        }
        if (timer.reachedMilestone(1))
        {
            tmp.SetText("2...");
        }
        if (timer.reachedMilestone(2))
        {
            tmp.SetText("1...");
        }
        if (timer.reachedMilestone(3))
        {
            tmp.SetText("Go!!!");
        }
        if (timer.reachedMilestone(4))
        {
            tmp.SetText("");
        }
    }
}
