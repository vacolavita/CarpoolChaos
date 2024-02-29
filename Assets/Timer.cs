using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float currentTime;
    public bool countingUp;
    public float timeMultiplier;
    public List<float> milestones;
    public bool destroyOnZero;
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (countingUp)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
        if (currentTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public bool reachedMilestone(int milestone) {
        if (milestones.ElementAt(milestone) >= currentTime)
        {
            return true;
        }
        else { 
            return false;
        }
    }

    public int addMilestone(float milestone) {
        milestones.Add(milestone);
        return milestones.Count-1;
    }
}
