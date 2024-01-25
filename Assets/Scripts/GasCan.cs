using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCan : MonoBehaviour
{
    public Movement car1;
    public Movement car2;
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

    public void Gas()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            car1.GasCanFill();
            gameManager.hasGasCan = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            car2.GasCanFill();
            gameManager.hasGasCan = false;
        }
    }
}
