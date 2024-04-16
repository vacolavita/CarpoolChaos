using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasOnFire : StageEvent
{
    public ParticleSystem fire;
    public GameObject waterBucket;
    public Vector3[] spawnPoints;
    int spawn;
    public GameObject gas;
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
        gas.GetComponent<OnFireBool>().fire = true;
        splashManager.makeSplash(1, "Event:\nGas Fire!");
        spawn = Random.Range(0, spawnPoints.Length);
        Instantiate(waterBucket);
        //car.isOnFire = true;
        waterBucket.transform.position = spawnPoints[spawn] + new Vector3(0, 1, 0);
        fire.Play();
    }
}
