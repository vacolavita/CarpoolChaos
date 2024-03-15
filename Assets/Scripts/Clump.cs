using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clump : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    bool taken = false;
    public int passengers = 0;
    public SpriteRenderer icon;

    //public Passenger pass;

    void Start()
    {
        icon = GetComponentInChildren<SpriteRenderer>();
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
        if (passengers > 0)
        {
            icon.enabled = false;
        }
        else {
            icon.enabled = true;
        }
    }
}
