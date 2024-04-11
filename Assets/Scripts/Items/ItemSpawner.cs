using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public float spawnTime = 30;
    float timer = 0;
    public GameObject item;
    public Vector3[] spawnPoints;
    int spawnPoint;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            timer -= spawnTime;
            spawnPoint = Random.Range(0, spawnPoints.Length);
            GameObject itemx = Instantiate(item, spawnPoints[spawnPoint] + new Vector3(0, 1, 0) , new Quaternion());
            itemx.transform.position = spawnPoints[spawnPoint] + new Vector3(0, 1, 0);
            spawnPoint = (spawnPoint + 1) % 3;
        }
    }
}
