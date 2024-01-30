using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float maxSpeed;
    public float traction;
    public float acceleration;
    public float handling;
    public float launchForce;
    public int carryingCapacity;
    public float fuelEfficiency;
    public float passengerPenalty;
    public float launchPenalty;

    public int currentPassengers;
    public GameObject[] passengers;
    public Vector3 launchTrajectory;
    private GameManager gameManager;
    
    //Variables for fuel
    public bool isMoving;
    public bool hasFuel;
    public float fuelLevel;
    public float maxFuel;
    private float gasToAdd;
    public Slider fuelMeter;

    Rigidbody r;
    float curSpeed;

    //Drop Variables

    public int select = 0;

    public int action = 0;

    public Vector2 controlDirection;

    // Start is called before the first frame update
    void Start()
    {

        passengers = new GameObject[carryingCapacity];
        r = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        SetMaxFuel(maxFuel);
        if (GameModes.turbo) {
            maxSpeed *= 1.3f;
        }
        if (GameModes.runningOnFumes)
        {
            maxSpeed /= 1.3f;
        }
        if (GameModes.wornOutWheels)
        {
            traction = ((traction-1)*0.7f)+1;
        }
        if (GameModes.superLaunch)
        {
            launchForce = launchForce *= 1.3f;
        }
        if (GameModes.stickyWheels)
        {
            traction = ((traction - 1) * 1.3f) + 1;
        }
        if (GameModes.bigCars)
        {
            GetComponentInParent<Transform>().localScale = new Vector3(1.3f,1.3f,1.3f);
        }
    }

    public void OnMove(InputValue value)
    {
        controlDirection = value.Get<Vector2>();
        //Debug.Log(c);
    }

    public void OnScrollLeft()
    {
        select = (select - 1) % 3;
        Debug.Log(select);
    }
    public void OnScrollRight()
    {
        select = (select + 1) % 3;
        Debug.Log(select);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 c = controlDirection;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, new Vector3(c.x,0,c.y), handling, 0.0f);
        if (c.magnitude > 1)
        {
            c.Normalize();
        }
        launchTrajectory = new Vector3(0, 4, 0) + transform.forward * (launchForce + (r.velocity.magnitude*0.3f));
        if (Vector2.Angle(new Vector2(r.velocity.x, r.velocity.z), c) > 90) //If the angle you're trying to move at is more than 90 degrees away from the direction you're facing, you'll slow down for a sharper turn
        {
            c *= 0.33f;
        } 
        curSpeed += c.magnitude * maxSpeed * (acceleration - 1) * (traction - 1);
        transform.rotation = Quaternion.LookRotation(newDirection);
        curSpeed /= acceleration;
        r.velocity += transform.forward * curSpeed;
        r.velocity = new Vector3(r.velocity.x/traction, r.velocity.y, r.velocity.z/traction);



        //Fuel Stuff
        if (curSpeed > 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        if (isMoving)
        {
            FuelDrain((curSpeed/maxSpeed)*(fuelEfficiency + (passengerPenalty*currentPassengers)));
        }
        
        if (fuelLevel <= 0)
        {
            hasFuel = false;
        }
        else
        {
            hasFuel = true;
            if (GameModes.gasLeak) {
                fuelLevel -= 0.03f;
                fuelMeter.value = fuelLevel;
            }
        }
        action = 0;
    }

    public Vector3 PassengerPosition(int passengerNum)
    {
        return new Vector3(((passengerNum - 1) % 3 - 1) *0.5f,1,Mathf.Floor((passengerNum - 1) / 3 - 1) * 0.5f);
    }

    public void FuelDrain(float amount)
    {
        if (hasFuel)
        {
            fuelLevel -= amount;
            SetFuel(fuelLevel);
        }
    }

    public void GasRefill()
    {
        fuelLevel = maxFuel;
        SetFuel(fuelLevel);
    }

    public void GasCanFill()
    {
        fuelLevel = Mathf.Min(fuelLevel+maxFuel*0.3f,maxFuel);
        SetFuel(fuelLevel);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gas Station"))
        {
            GasRefill();
        }
        if (other.gameObject.CompareTag("Clump"))
        {
            other.GetComponent<Clump>().player = gameObject;
        }
    }

    public void SetMaxFuel(float fuel)
    {
        fuelMeter.maxValue = fuel;

        fuelMeter.value = fuel;
    }

    public void SetFuel(float fuel)
    {
        fuelMeter.value = fuel;
    }









    public void OnLaunch()
    {
        if (hasFuel && currentPassengers > 0)
        {
            action = 1;
            fuelLevel = Mathf.Max(fuelLevel-launchPenalty,0);
            SetFuel(fuelLevel);
        }
    }

    public void OnDrop()
    {
        action = 2;
    }


}