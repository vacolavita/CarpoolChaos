using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screams : MonoBehaviour
{
    public AudioClip[] screams; 
    void Start()
    {
        GetComponent<AudioSource>().clip = screams[Random.Range(0,screams.Length)];
        GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
