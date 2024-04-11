using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasOnFire : StageEvent
{
    public ParticleSystem fire;
    private GameManager gameManager;
    public GameObject waterBucket;
    public Vector3[] spawnPoints;
    int spawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Trigger()
    {
        splashManager.makeSplash(1, "Event:\nGas Fire!");
        spawn = Random.Range(0, spawnPoints.Length);
        Instantiate(waterBucket);
        waterBucket.transform.position = spawnPoints[spawn] + new Vector3(0, 1, 0);
        fire.Play();
    }
}
