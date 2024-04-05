using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody body;
    public GameObject[] cars;
    public int[] distances;
    public int[] indexes;
    public bool startShuffle;
    public float speed = 0.225f;
    public float time = -450;

    void Start()
    {

        body = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        body.MovePosition(transform.position + new Vector3(0, 0, speed));
        if (transform.position.z > 280) {
            transform.position += new Vector3(0, 0, time);
            Shuffle();
        }
        if (!startShuffle) {
            startShuffle = true;
            Shuffle();
        }
    }

    void Shuffle() {
        reshuffle(indexes);
        int dist = 135;
        foreach (var item in indexes) {
            cars[item].transform.localPosition = new Vector3(dist, 0, 0);
            dist += distances[item];
        }
        cars[7].GetComponent<SpecialCar>().Activate();
    }

    void reshuffle(int[] texts)
    {
        for (int t = 0; t < texts.Length; t++)
        {
            int tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }
}
