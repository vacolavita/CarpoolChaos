using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clump : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    bool taken = false;
    private GameManager gameManager;
    //public Passenger pass;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
