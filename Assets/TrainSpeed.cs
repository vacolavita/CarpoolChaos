using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpeed : StageEvent
{
    public GameObject train;
    Timer timer;
    bool active;

    private void Start()
    {
        timer = GetComponent<Timer>();
    }
    public override void Trigger()
    {
        splashManager.makeSplash(1, "Event:\nWild Train!");
        train.GetComponent<Train>().speed += 0.225f;
        train.GetComponent<Train>().time += 70f;
        timer.addMilestone(60, true);
        active = true;

    }

    private void Update()
    {
        if (active && timer.reachedMilestone(0)) {
            train.GetComponent<Train>().speed -= 0.225f;
            train.GetComponent<Train>().time -= 70f;
            active = false;
        }
    }
}
