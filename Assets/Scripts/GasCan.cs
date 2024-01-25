using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCan : MonoBehaviour
{
    private Movement car1;
    private Movement car2;
    // Start is called before the first frame update
    void Start()
    {
        car1 = GameObject.Find("Car 1").GetComponent<Movement>();
        car2 = GameObject.Find("Car 2").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            car1.GasCanFill();
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            car2.GasCanFill();
        }
    }
}
