using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Spawner : MonoBehaviour
{
    public float spawnTime = 10;
    public float timer = 3;
    public float spawnTimeAdjusted;
    public GameObject pass;
    int spawnPoint = 1;
    int spawnType;
    public int passClump;
    public int passAmount;
    public float despawnRate = 60;
    public float timeMultiplier = 1;
    public stageManager stage;
    public GameManager gameManager;
    public bool rush = false;

    void Start()
    {
        stage = GameObject.Find("StageManager").GetComponent<stageManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        timer = spawnTime-6;
        spawnTimeAdjusted = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeDecrease();

        timeMultiplier = 1 + ((StaticGameManager.passengersOut)*0.05f);
        if (StaticGameManager.passengersOut == 0)
        {
            timeMultiplier = 0.5f;
        }

        timer += Time.deltaTime / timeMultiplier;
        if (timer >= spawnTimeAdjusted)
        {
            timer -= spawnTimeAdjusted;
            spawnPoint = Random.Range(0, stage.stops.Length);
            splashManager.makeSplash(2, "New Passengers!");
            for (int j = passClump; j > 0; j--)
            {
                spawnType = Random.Range(1, 4);
                for (int i = passAmount - (passClump-j); i > 0; i--)
                {
                    if (GameModes.mixUp)
                    {
                        spawnType = Random.Range(1, 4);
                    }
                    GameObject passenger = Instantiate(pass, stage.stops[spawnPoint] + new Vector3(Random.Range(-2.0f, 2.0f), 0, Random.Range(-2.0f, 2.0f)), new Quaternion());
                    passenger.SetActive(false);
                    StaticGameManager.passengersOut += 1;
                    passenger.GetComponent<Passenger>().clump = stage.clumps[spawnPoint].GetComponent<Clump>();
                    passenger.GetComponent<Passenger>().clump.passengers++;
                    passenger.GetComponent<Passenger>().passengerType = spawnType;
                    passenger.SetActive(true);
                }
                spawnPoint = (spawnPoint + 1) % 3;
            }
        }
        if (gameManager.rush && !rush) {
            rush = true;
            spawnTime--;
            passClump++;
        }
    }

    public void TimeDecrease()
    {
        if (GameModes.useLives)
        {
            spawnTimeAdjusted = spawnTime / (1 + (Time.deltaTime / 150.0f));
        }
        else
        {
            spawnTimeAdjusted = spawnTime / (1 + (gameManager.score / 150.0f));
        }
    }
}
