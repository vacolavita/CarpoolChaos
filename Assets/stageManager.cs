using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageManager : MonoBehaviour
{
    public Vector3[] dests;
    public Vector3[] stops;
    public Vector3 fuel;
    public GameObject clump;
    [SerializeReference] public StageEvent[] events;
    public float timer;

    [NonSerialized] public GameObject[] clumps;
    void Start()
    {
        
        clumps = new GameObject[stops.Length];
        int i = 0;
        foreach (var item in stops){
            clumps[i] = Instantiate(clump, item, new Quaternion());
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 60) {
            timer = -9999;
            events[0].Trigger();
        }
    }
}
