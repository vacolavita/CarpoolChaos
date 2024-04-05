using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpeed : StageEvent
{
    public GameObject train;

    public override void Trigger()
    {
        splashManager.makeSplash(1, "Event:\nTrain Speed Up!");
        train.GetComponent<Train>().speed += 0.225f;
    }
}
