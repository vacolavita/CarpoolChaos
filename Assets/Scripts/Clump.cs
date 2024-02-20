using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clump : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    bool taken = false;
    public int passengers = 0;

    //public Passenger pass;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (taken) {
            taken = false;
            player = null;
        }

        if (player != null)
        {
            taken = true;
        }

    }
}
