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
    public GameObject pas;
    public float floor;
    [SerializeReference] public StageEvent[] events;
    public Vector3[] spawnPoints;
    public float timer;
    public GameObject player;

    [NonSerialized] public GameObject[] clumps;
    void Start()
    {
        int col = UnityEngine.Random.Range(1, 4);
        int i = 0;
        foreach (var p in spawnPoints) {
            GameObject play = Instantiate(player, p, new Quaternion());
            play.name = "Player " + (i + 1);
            Movement m = play.GetComponent<Movement>();
            m.playernum = i;
            i++;
            GameObject.Find("P" + i + " Cam").GetComponent<CameraFollow>().cameraFollow = play.transform;
            if (col == 1)
            {
                if (i == 1)
                {
                    m.paint = new Color(1, 0.2f, 0.2f);
                }
                if (i == 2)
                {
                    m.paint = new Color(0.3f, 0.4f, 1);
                }
            }
            if (col == 2)
            {
                if (i == 1)
                {
                    m.paint = new Color(0.8f, 0.8f, 0.2f);
                }
                if (i == 2)
                {
                    m.paint = new Color(0.2f, 0.3f, 0.7f);
                }
            }
            if (col == 3)
            {
                if (i == 1)
                {
                    m.paint = new Color(0.2f, 0.8f, 0.4f);
                }
                if (i == 2)
                {
                    m.paint = new Color(1f, 0.2f, 0.7f);
                }
            }
        }
        clumps = new GameObject[stops.Length];
        i = 0;
        foreach (var item in stops){
            clumps[i] = Instantiate(clump, item, new Quaternion());
            GameObject p = Instantiate(pas, item, new Quaternion());
            p.GetComponentInChildren<MapIcon>().depth = floor;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 63) {
            timer = -9999;
            events[UnityEngine.Random.Range(0, events.Length)].Trigger();
            
        }
    }
}
