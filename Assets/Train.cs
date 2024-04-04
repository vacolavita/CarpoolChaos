using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody body;
    public GameObject[] cars;
    public int[] indexes;

    //258
    void Start()
    {

        body = GetComponent<Rigidbody>();
        Shuffle();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.MovePosition(transform.position + new Vector3(0, 0, 0.25f));
        if (transform.position.z > 350) {
            transform.position += new Vector3(0, 0, -500);
            Shuffle();
        }

    }

    void Shuffle() {
        reshuffle(indexes);
        int dist = 117;
        foreach (var item in indexes) {
            cars[item].transform.localPosition = new Vector3(dist, 0, 0);
            if (item != 7)
            {
                dist += 259;
            }
            else {
                dist += 130;
                cars[item].GetComponent<SpecialCar>().Activate();
            }
        }
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
