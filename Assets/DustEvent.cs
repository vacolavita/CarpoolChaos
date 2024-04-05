using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEvent : StageEvent
{
    public ParticleSystem ParticleSystem;
    public override void Trigger()
    {
        splashManager.makeSplash(1, "Event:\nDust Storm!");
        ParticleSystem.Play();
    }
}
