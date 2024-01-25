using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public float spawnTime = 10;
    float timer = 0;
    public GameObject item;
    int spawnPoint;

    // Start is called before the first frame update
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
            GameObject itemx = Instantiate(item);
            itemx.transform.position = new Vector3(Random.Range(-16.0f, 16.0f), 1, Random.Range(-16.0f, 16.0f));
        }
    }
}
