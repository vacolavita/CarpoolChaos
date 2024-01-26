using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime = 10;
    float timer = 0;
    public GameObject pass;
    public Vector3[] spawnPoints;
    public GameObject[] spawnGroups;
    int spawnPoint;
    int spawnType;
    public int passClump;
    public int passAmount;

    void Start()
    {
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            timer -= spawnTime;
            spawnPoint = Random.Range(0, spawnPoints.Length);

            for (int j = passClump; j > 0; j--)
            {
                spawnType = Random.Range(1, 4);
                for (int i = passAmount; i > 0; i--)
                {
                    GameObject passenger = Instantiate(pass);
                    passenger.transform.position = spawnPoints[spawnPoint] + new Vector3(Random.Range(-2.0f, 2.0f), 0, Random.Range(-2.0f, 2.0f));
                    passenger.GetComponent<Passenger>().group = spawnGroups[spawnPoint];
                    passenger.GetComponent<Passenger>().passengerType = spawnType;
                }
                spawnPoint = (spawnPoint + 1) % 3;
            }
        }
    }

}
