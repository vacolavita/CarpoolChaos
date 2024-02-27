using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPeels : StageEvent
{
    public GameObject peels;
    public Vector3[] spawnPoints;
    public override void Trigger()
    {
        splashManager.makeSplash(1, "Event:\nBanana Peels!");
        foreach (var p in spawnPoints)
        {
            Instantiate(peels, p, new Quaternion());
        }
    }
}
