using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clump : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    bool taken = false;

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
