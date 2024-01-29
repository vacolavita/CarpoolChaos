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
    int spawnPoint;
    int spawnType;
    public int passClump;
    public int passAmount;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        timer = spawnTime;
        spawnTimeAdjusted = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        spawnTimeAdjusted = spawnTime/ 1 + (gameManager.score/10);

        if (GameModes.useLives)
        {
            spawnTimeAdjusted = spawnTime / 1 + (Time.deltaTime / 10);
        }

        timer += Time.deltaTime;
        if (timer >= spawnTimeAdjusted)
        {
            timer -= spawnTime;
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

}
