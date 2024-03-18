using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWrapper : MonoBehaviour
    
{
    private static PlayerWrapper instance;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;

        }
        else {
            Destroy(gameObject);
        }
    }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        PlayerManagerManager.players = new GameObject[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
