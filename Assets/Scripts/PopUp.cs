using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buildPopUp(Material m, Color c, float scale, bool wiggle) {
        GetComponent<ParticleSystemRenderer>().material = m;
        GetComponent<ParticleSystemRenderer>().material.color = c;
        var main = GetComponent<ParticleSystem>().main;
        main.startSize = scale;


        if (wiggle)
        {
            var n = GetComponent<ParticleSystem>().noise;
            n.positionAmount = 0.3f;
        }
        else {
            var n = GetComponent<ParticleSystem>().noise;
            n.positionAmount = 0f;

        }
    }
}
