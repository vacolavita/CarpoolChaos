using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasOnFire : MonoBehaviour
{
    public ParticleSystem fire;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireStart()
    {
        fire.Play();
    }
}
