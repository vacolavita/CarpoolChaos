using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalEvent : StageEvent
{
    Timer timer;
    public GameObject rival;
    public GameObject r;
    public Vector3 coords;
    bool active;
    private void Start()
    {
        timer = GetComponent<Timer>();
    }
    public override void Trigger()
    {
        splashManager.makeSplash(1, "Event:\nRival!");
        r = Instantiate(rival,coords, new Quaternion());
        timer.addMilestone(60, true);
        active = true;

    }

    private void Update()
    {
        if (active && timer.reachedMilestone(0))
        {
            r.GetComponent<Movement>().OnDrop();
            Destroy(r);
            active = false;
        }
    }
}
