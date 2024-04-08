using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Scream : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = GetComponent<SoundStore>().sounds[Random.Range(0, GetComponent<SoundStore>().sounds.Length)];
        GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
