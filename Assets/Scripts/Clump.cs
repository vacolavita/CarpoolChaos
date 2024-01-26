using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clump : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] passengers;
    public bool[] typeAcceptance;
    public bool isSpawnClump;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //If touching car, make car collect passengers based on, in this order:
    //Matching Color (is this color already on the car?)
    //Age (How old is this passenger?)
}
