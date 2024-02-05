using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime = 10;
    float timer = 0;
    public float spawnTimeAdjusted;
    public GameObject pass;
    public Vector3[] spawnPoints;
    public GameObject[] spawnGroups;
    int spawnPoint = 1;
    int spawnType;
    public int passClump;
    public int passAmount;
    private GameManager gameManager;
    public float despawnRate = 60;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        timer = spawnTime;
        spawnTimeAdjusted = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeDecrease();

        timer += Time.deltaTime;
        if (timer >= spawnTimeAdjusted)
        {
            timer -= spawnTimeAdjusted;
            spawnPoint = Random.Range(0, spawnPoints.Length);
            for (int j = passClump; j > 0; j--)
            {
                spawnType = Random.Range(1, 4);
                for (int i = passAmount; i > 0; i--)
                {
                    if (GameModes.mixUp) {
                        spawnType = Random.Range(1, 4);
                    }
                    GameObject passenger = Instantiate(pass);
                    passenger.transform.position = spawnPoints[spawnPoint] + new Vector3(Random.Range(-2.0f, 2.0f), 0, Random.Range(-2.0f, 2.0f));
                    passenger.GetComponent<Passenger>().clump = spawnGroups[spawnPoint].GetComponent<Clump>();
                    passenger.GetComponent<Passenger>().passengerType = spawnType;
                }
                spawnPoint = (spawnPoint + 1) % 3;
            }
        }
    }

    public void TimeDecrease()
    {
        if (GameModes.useLives)
        {
            spawnTimeAdjusted = spawnTime / (1 + (Time.deltaTime / 100.0f));
        }
        else
        {
            spawnTimeAdjusted = spawnTime / (1 + (gameManager.score / 100.0f));
            //Debug.Log("bleg");
        }
    }
}
