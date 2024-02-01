using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.WSA;
using static System.Net.Mime.MediaTypeNames;
using static UnityEditor.Progress;

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
    public float jumpForce = 10f;

    public bool boostSpeed;

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

    public int item = 0;

    public Vector2 controlDirection;

    public Transform carTransform;

    public GameObject[] items;

    public int playernum = 0;

    public GameObject playerControl;

    public Color paint;

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
        if (PlayerManagerManager.players == null) {
            PlayerManagerManager.players = new GameObject[2];
            Debug.Log("AH");

        }
        

    }

    public void OnMove(InputValue value) {
        controlDirection = value.Get<Vector2>();
    }

    public void OnScrollLeft()
    {

        select -= 1;
        if (select < 0)
            select = 2;

        foreach (var item1 in GetComponentsInChildren<Light>())
        {
            if (select == 0) {
                item1.color = Color.green;
            }
            if (select == 1)
            {
                item1.color = new Color(1.00f, 0.5f, 0.4f);
            }
            if (select == 2)
            {
                item1.color = new Color(0.50f, 0.92f, 1.00f);
            }
        }

    }
    public void OnScrollRight()
    {
        select = (select + 1) % 3;

        foreach (var item1 in GetComponentsInChildren<Light>())
        {
            if (select == 0)
            {
                item1.color = Color.green;
            }
            if (select == 1)
            {
                item1.color = new Color(1.00f, 0.5f, 0.4f);
            }
            if (select == 2)
            {
                item1.color = new Color(0.50f, 0.92f, 1.00f);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        PlayerManagerManager.players[playernum] = gameObject;
        

        Vector2 c = controlDirection;
        GetComponentsInChildren<MeshRenderer>()[4].materials[0].color = paint;
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

        if (boostSpeed)
        {
            curSpeed *= 1.25f;
        }

        if (fuelLevel <= 0)
        {
            hasFuel = false;
        }



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

        FuelGone();
    }

    public Vector3 PassengerPosition(int passengerNum)
    {
        return new Vector3(((passengerNum - 1) % 3 - 1) *0.5f,1,(Mathf.Floor((passengerNum - 1) / 3 - 1) * 0.5f)-0.5f);
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

        if (other.gameObject.CompareTag("Boost Pad"))
        {
            boostSpeed = true;
        }
        else
        {
            boostSpeed = false;
        }

        if (other.gameObject.CompareTag("Spring Pad"))
        {
            r.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (other.gameObject.CompareTag("Ice"))
        {
            traction = ((traction - 1) * 0.7f) + 1;
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

    public void FuelGone()
    {
        if (!hasFuel)
        {
            curSpeed /= 1.05f;
        }
    }









    public void OnLaunch()
    {
        if (hasFuel && currentPassengers > 0)
        {
            bool launched = false;
            for (int i = 0; i < carryingCapacity; i++) {
                if (passengers[i] != null)
                {
                    Passenger p = passengers[i].GetComponent<Passenger>();
                    if (p.passengerType-1 == select)
                    {
                        launched = true;
                        p.isInCar = false;
                        passengers[i].transform.SetParent(null);
                        p.GetComponent<Rigidbody>().isKinematic = false;
                        p.GetComponent<Rigidbody>().velocity = launchTrajectory + new Vector3(Random.Range(-1.0f, 1.0f), 0, (Random.Range(-1.0f, 1.0f)));
                        currentPassengers--;
                        p.canTrigger = false;
                        passengers[i] = null;
                    }
                }
            }
            if (launched)
            {
                fuelLevel = Mathf.Max(fuelLevel - launchPenalty, 0);
                SetFuel(fuelLevel);
            }
        }
    }

    public void OnDrop()
    {
        for (int i = 0; i < carryingCapacity; i++)
        {
            if (passengers[i] != null)
            {
                Passenger p = passengers[i].GetComponent<Passenger>();
                if (p.passengerType - 1 == select)
                {
                    p.isInCar = false;
                    passengers[i].transform.SetParent(null);
                    p.GetComponent<Rigidbody>().isKinematic = false;
                    p.GetComponent<Rigidbody>().velocity = p.transform.forward * -4;
                    currentPassengers--;
                    p.canTrigger = false;
                    passengers[i] = null;
                }
            }
        }
    }

    public void OnItem() 
    {
        if (item == 1) 
        {
            GameObject gas = Instantiate(items[0], carTransform.position, transform.rotation);
            gas.GetComponent<Rigidbody>().velocity = transform.forward * maxSpeed * 2;
            gameManager.hasItem = false;
        }
        if (item == 2)
        {
            Instantiate(items[1], carTransform.position, transform.rotation);
            gameManager.hasItem = false;
        }
        if (item == 3)
        {
            Instantiate(items[2], transform.position + new Vector3(0, -0.92f, 0), transform.rotation);
            gameManager.hasItem = false;
        }
        if (item == 4)
        {
            Instantiate(items[3], transform.position + new Vector3(0, -0.92f, 0), transform.rotation);
            gameManager.hasItem = false;
        }
        else
        {
            gameManager.hasItem = false;
        }

        item = 0;
    }


}