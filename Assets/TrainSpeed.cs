using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpeed : StageEvent
{
    public GameObject train;

    public override void Trigger()
    {
        splashManager.makeSplash(1, "Event:\nWild Train!");
        train.GetComponent<Train>().speed += 0.225f;
        train.GetComponent<Train>().time += 70f;
    }
}
