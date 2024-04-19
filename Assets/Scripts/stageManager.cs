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
    public GameObject[] player;
    colorManager color;

    [NonSerialized] public GameObject[] clumps;
    void Start()
    {
        
        int i = 0;
        color = GetComponent<colorManager>();
        foreach (var p in spawnPoints) {
            GameObject play = Instantiate(player[VehicleSelection.playerVehicle[i]], p, new Quaternion());
            play.name = "Player " + (i + 1);
            Movement m = play.GetComponent<Movement>();
            m.paint = color.colors[VehicleSelection.playerVehicleColor[i]];
            m.playernum = i;
            i++;
            GameObject.Find("P" + i + " Cam").GetComponent<CameraFollow>().cameraFollow = play.transform;
            Debug.Log("Spawn Complete");
        }
        clumps = new GameObject[stops.Length];
        i = 0;
        foreach (var item in stops){
            clumps[i] = Instantiate(clump, item, new Quaternion());
            GameObject p = Instantiate(pas, item, new Quaternion());
            p.GetComponentInChildren<MapIcon>().depth = floor;
            i++;
            Debug.Log("Stop Complete");
        }
        GameObject.Find("Game Manager").GetComponent<GameManager>().countdown = 3;
        Debug.Log("stageManager Complete");
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
