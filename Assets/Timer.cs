using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float dTime = -1;
    public List<float> milestones;
    public bool destroy;
    public float destroyAt;
    

    void Start()
    {
        dTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (destroy && Time.time >= destroyAt + dTime) {
            Destroy(gameObject);
        }
    }

    public bool reachedMilestone(int milestone) {
        if (dTime == -1)
        {
            return false;
        }
        if (milestones.ElementAt(milestone) + dTime <= Time.time)
        {
            return true;
        }
        else { 
            return false;
        }
    }

    public int addMilestone(float milestone, bool fromNow) {
        if (!fromNow)
        {
            milestones.Add(milestone);
            return milestones.Count - 1;
        }
        else {
            milestones.Add(milestone + (Time.time - dTime));
            return milestones.Count - 1;
        }
    }

    public void restart() {
        dTime = Time.time;
    }
}
