using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWrapper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        PlayerManagerManager.players = new GameObject[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
