using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
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
    public float jumpForce = 5f;
    public ParticleSystem slipStream;

    public ParticleSystem exhaust;


    public int currentPassengers;
    
    //Variables for fuel
    public bool isMoving;
    public bool hasFuel;
    public float fuelLevel;
    public float maxFuel;
    private float gasToAdd;
    public Transform carMesh;

    Rigidbody r;
    float curSpeed;

    //Drop Variables

    public int select = 0;

    public int item = 0;

    public Vector2 controlDirection;

    public GameObject[] items;

    public int playernum = 0;

    public GameObject playerControl;

    public Color paint;

    public GameObject[] passengers;
    public Vector3 launchTrajectory;
    private GameManager gameManager;
    float boostSpeed;
    public GameObject popUp;
    public Material outOfGas;
    public Material capacity;

    public GameObject marker;

    public GameObject[] markers;

    bool atCapacity;

    public bool DebugAI;
    bool DebugFueling;

    int spinOut = 0;

    //float lean = 0;

    stageManager stage;

    float onGround;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        GetComponent<CapsuleCollider>().material.dynamicFriction = 0;
        GetComponent<CapsuleCollider>().material.staticFriction = 0;
        GetComponent<MeshCollider>().material.dynamicFriction = 0;
        GetComponent<MeshCollider>().material.staticFriction = 0;
        markers = new GameObject[3];
        stage = GameObject.Find("StageManager").GetComponent<stageManager>();

        passengers = new GameObject[carryingCapacity];
        r = GetComponent<Rigidbody>();
        r.maxAngularVelocity = 50;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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

        }
        GetComponentsInChildren<MeshRenderer>()[0].materials[0].color = paint;
        GetComponentsInChildren<SpriteRenderer>()[0].color = paint;
        
    }
    
    public void OnMove(InputValue value) {

        controlDirection = value.Get<Vector2>();
    }

    public void OnScrollLeft()
    {
        UpdateColor(-1);
    }
    
    public void OnScrollRight()
    {
        UpdateColor(1);
    }

    // Update is called once per frame

    private void Update()
    {
        if (Score.gameOver)
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if (Score.gameOver)
        {
            Destroy(gameObject);
        }

        //carMesh.transform.localScale = Vector3.one*Time.time;
        //carMesh.Rotate(0,0,10);
        onGround += 2;
        onGround = Mathf.Clamp(onGround,0, 20);
        carMesh.localRotation = Quaternion.Euler(-onGround, 0, 0);
        PlayerManagerManager.players[playernum] = gameObject;

        if (stage.clumps[0] != null && (stage.clumps[0].GetComponent<Clump>().passengers > 0 || stage.clumps[1].GetComponent<Clump>().passengers > 0 || stage.clumps[2].GetComponent<Clump>().passengers > 0) && currentPassengers == 0)
        {
            if (markers[2] == null)
            {
                markers[2] = Instantiate(marker);
                markers[2].transform.SetParent(transform);
                markers[2].GetComponent<markerManager>().depth = 0.25f;

            }

            markers[2].GetComponent<markerManager>().dest[0] = stage.stops[0];
            markers[2].GetComponent<markerManager>().dest[1] = stage.stops[1];
            markers[2].GetComponent<markerManager>().dest[2] = stage.stops[2];
            markers[2].GetComponent<markerManager>().color = new Color(0.8f, 0.8f, 0.0f);
            markers[2].GetComponent<markerManager>().numDests = 3;
            markers[2].GetComponent<markerManager>().pointStops = true;
        }
        else {
            if (markers[2] != null)
            {
                Destroy(markers[2]);
            }
        }

        if (DebugAI) {
            bool nav = false;
            foreach (var item1 in markers)
            {
                if (item1 != null && !nav) {
                    controlDirection = new Vector2(item1.transform.forward.x, item1.transform.forward.z);
                    controlDirection.Normalize();
                    nav = true;
                }
            }
            if (nav == false){
                controlDirection = Vector2.zero;
            }
            if (DebugFueling) {
                controlDirection = Vector2.zero;
            }
        }
        Vector2 c = controlDirection;
        if (!StaticGameManager.control)
        {
            c = Vector3.zero;
        }
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, new Vector3(c.x,0,c.y), handling, 0.0f);
        if (c.magnitude > 1)
        {
            c.Normalize();
        }
        if (GameModes.lobber)
        {
            launchTrajectory = new Vector3(0, 12, 0) + transform.forward * (launchForce + (r.velocity.magnitude * 0.3f));
        }
        else
        {
            launchTrajectory = new Vector3(0, 4, 0) + transform.forward * (launchForce + (r.velocity.magnitude * 0.3f));
        }
        
        if (spinOut > 0) { 
            c = new Vector3(0, 0, 0);
            curSpeed = 0;
            spinOut--;
            r.angularVelocity = Vector3.zero;
            r.AddTorque(new Vector3(0,10,0), ForceMode.VelocityChange);
        }
        else
        {
            r.angularVelocity = Vector3.zero;
        }

        if (Vector2.Angle(new Vector2(r.velocity.x, r.velocity.z), c) > 90) //If the angle you're trying to move at is more than 90 degrees away from the direction you're facing, you'll slow down for a sharper turn
        {
            c *= 0.33f;
        }

        if (boostSpeed > 0)
        {
            boostSpeed--;
            curSpeed += maxSpeed * 2.5f * (acceleration - 1) * (traction - 1);
            launchTrajectory = new Vector3(0, 4, 0) + transform.forward * (launchForce + (r.velocity.magnitude));
        }
        else{
            curSpeed += c.magnitude * maxSpeed * (acceleration - 1) * (traction - 1);
            slipStream.Stop();
        }

        //lean += (transform.forward - newDirection).magnitude * r.velocity.magnitude * 4;
        //lean = Mathf.Clamp(lean, -20, 20);
        //carMesh.localRotation = Quaternion.Euler(0,0,lean);
        //Debug.Log(name + " " + lean);
        if (spinOut <= 0) {
            r.MoveRotation(Quaternion.LookRotation(newDirection));
        }

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
            FuelDrain(Mathf.Min((curSpeed/maxSpeed)*(fuelEfficiency + (passengerPenalty*currentPassengers)), fuelEfficiency + (passengerPenalty * currentPassengers)));

            ExhaustPlay();
        }
        
        if (fuelLevel <= 0)
        {
            if (hasFuel) {
                GameObject pop = Instantiate(popUp, transform.position + new Vector3(0,2,0), Quaternion.Euler(-70, 0, 0));
                pop.GetComponent<PopUp>().buildPopUp(outOfGas, new Color(1f,0.1f,0.1f), 10, false);
            }
            hasFuel = false;
        }

        else
        {
            hasFuel = true;
            if (GameModes.gasLeak) {
                fuelLevel -= 0.03f;
            }
        }

        if (fuelLevel < 30)
        {
            if (markers[1] == null)
            {
                markers[1] = Instantiate(marker);
                markers[1].transform.SetParent(transform);
                markers[1].GetComponent<markerManager>().depth = 0.5f;

            }

            markers[1].GetComponent<markerManager>().dest[0] = stage.fuel;
            markers[1].GetComponent<markerManager>().color = new Color(0.7f, 0.4f, 0.2f);
            markers[1].GetComponent<markerManager>().numDests = 1;
            markers[1].GetComponent<markerManager>().pointStops = false;
        }
        else {
            if (markers[1] != null)
            {
                Destroy(markers[1]);
            }
        }

        FuelGone();
        ///////////////////////////////////////////////////////////////
        if (!atCapacity && carryingCapacity == currentPassengers) { 
            atCapacity = true;
            GameObject pop = Instantiate(popUp, transform.position + new Vector3(0, 2, 0), Quaternion.Euler(-70, 0, 0));
            pop.GetComponent<PopUp>().buildPopUp(capacity, Color.white, 7, false);
        }
        if (atCapacity && carryingCapacity != currentPassengers)
        {
            atCapacity = false;
        }
    }



















    public Vector3 PassengerPosition(int passengerNum)
    {
        return new Vector3(((passengerNum - 1) % 3 - 1) *0.5f,2.1f,(Mathf.Floor((passengerNum - 1) / 3 - 1) * -0.5f)-0.7f) * (1/carMesh.localScale.x);
    }

    public void FuelDrain(float amount)
    {
        if (hasFuel)
        {
            fuelLevel -= amount;
        }
    }

    public void GasRefill()
    {
        fuelLevel = maxFuel;
    }

    public void GasCanFill()
    {
        fuelLevel = Mathf.Min(fuelLevel+maxFuel*0.3f,maxFuel);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Clump"))
        {
            other.GetComponent<Clump>().player = gameObject;
        }

        if (other.gameObject.CompareTag("Boost Pad"))
        {
            boostSpeed = 80;
            slipStream.Play();
        }

        if (other.gameObject.CompareTag("Spring Pad"))
        {
            r.velocity = new Vector3 (r.velocity.x, jumpForce, r.velocity.z);
        }

        if (other.gameObject.CompareTag("Ice"))
        {
            traction = ((traction - 1) * 0.7f) + 1;
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            spinOut = 60;
            Destroy(other.gameObject);
            SpinPassengers();
        }

        if (other.gameObject.CompareTag("Destination")) {
            foreach (var item1 in passengers)
            {
                if (item1 != null)
                {
                    item1.GetComponent<Passenger>().scorePassenger(other, true);
                }
            }
        }
    }


    public void FuelGone()
    {
        if (!hasFuel)
        {
            curSpeed /= 1.05f;
            exhaust.Stop();

        }
    }

    public void ExhaustPlay()
    {
        if (hasFuel)
        {
            //Debug.Log("Emit Exhaust");
            exhaust.Play();
        }
    }

    public void SpinPassengers() {
        int count = currentPassengers;
        for (int i = 0; i < carryingCapacity; i++) {
            if (passengers[i] != null) {
                Passenger p = passengers[i].GetComponent<Passenger>();
                p.isInCar = false;
                passengers[i].transform.SetParent(null);
                p.GetComponent<Rigidbody>().isKinematic = false;
                currentPassengers--;
                p.canTrigger = false;
                passengers[i] = null;
                p.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
                p.transform.rotation = Quaternion.Euler(0, transform.rotation.y + 360/count * (i + 0.5f), 0);
                p.GetComponent<Rigidbody>().velocity = p.transform.forward * (6 + Random.Range(0,2f)) + new Vector3(0, 1, 0);
                UpdateColor(0);
            }
        }
    }







    public void OnLaunch()
    {
        if (StaticGameManager.control)
        {
            if (hasFuel && currentPassengers > 0)
            {
                bool launched = false;
                for (int i = 0; i < carryingCapacity; i++)
                {
                    if (passengers[i] != null)
                    {
                        Passenger p = passengers[i].GetComponent<Passenger>();
                        if (p.passengerType - 1 == select)
                        {
                            launched = true;
                            p.isInCar = false;
                            passengers[i].transform.SetParent(null);
                            p.GetComponent<Rigidbody>().isKinematic = false;
                            p.GetComponent<Rigidbody>().velocity = launchTrajectory + new Vector3(Random.Range(-1.0f, 1.0f), 0, (Random.Range(-1.0f, 1.0f)));
                            currentPassengers--;
                            p.canTrigger = false;
                            passengers[i] = null;
                            p.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;

                        }
                    }
                }
                if (launched)
                {
                    fuelLevel = Mathf.Max(fuelLevel - launchPenalty, 0);
                    UpdateColor(1);
                }
            }

        }
    }

        public void OnDrop()
    {
        if (StaticGameManager.control)
        {
            bool dropped = false;
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
                        dropped = true;
                        p.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
                    }
                }
            }
            if (dropped)
            {
                UpdateColor(1);
            }
        }
    }

    public void OnItem() 
    {
        if (StaticGameManager.control)
        {
            if (item == 1)
            {
                GameObject gas = Instantiate(items[0], transform.position + new Vector3(0, 2, 0), transform.rotation);
                gas.GetComponent<Rigidbody>().velocity = launchTrajectory;
                splashManager.makeSplash(2, "Gas Can!");
            }
            if (item == 2)
            {
                Instantiate(items[1], transform.position + new Vector3(0, -0.92f, 0), transform.rotation);
                splashManager.makeSplash(2, "Boost Pad!");
            }
            if (item == 3)
            {
                Instantiate(items[2], transform.position + new Vector3(0, -1f, 0), transform.rotation);
                splashManager.makeSplash(2, "Tent!");
            }
            if (item == 4)
            {
                Instantiate(items[3], transform.position + new Vector3(0, -0.92f, 0), transform.rotation);
                splashManager.makeSplash(2, "Jump Pad!");
            }

            item = 0;
        }
    }

    public void UpdateColor(int selectChange) {
        if (currentPassengers > 0)
        {

            bool[] types = new bool[3];
            foreach (var item1 in passengers)
            {
                if (item1 != null)
                {
                    types[item1.GetComponent<Passenger>().passengerType - 1] = true;
                }
            }

            int loops = 0;
            select = (select + selectChange) % 3;
            if (select < 0)
                select = 2;
            while (types[select] == false)
            {
                select = (select + selectChange) % 3;
                if (select < 0)
                    select = 2;
                loops++;
                if (loops == 3 && selectChange == 0) {
                    selectChange = 1;
                }
            }
            foreach (var item1 in GetComponentsInChildren<Light>())
            {
                if (select == 0)
                {
                    item1.color = Color.green;
                    if (markers[0] == null)
                    {
                        markers[0] = Instantiate(marker);
                        markers[0].transform.SetParent(transform);

                    }
                    markers[0].GetComponent<markerManager>().dest[0] = stage.dests[0];
                    markers[0].GetComponent<markerManager>().color = new Color(0.1f, 1f, 0.1f);
                    markers[0].GetComponent<markerManager>().numDests = 1;
                    markers[0].GetComponent<markerManager>().pointStops = false;
                }
                if (select == 1)
                {
                    item1.color = new Color(1.00f, 0.5f, 0.4f);
                    if (markers[0] == null)
                    {
                        markers[0] = Instantiate(marker);
                        markers[0].transform.SetParent(transform);

                    }
                    markers[0].GetComponent<markerManager>().dest[0] = stage.dests[1];
                    markers[0].GetComponent<markerManager>().color = new Color(1, 0.1f, 0.1f);
                    markers[0].GetComponent<markerManager>().numDests = 1;
                    markers[0].GetComponent<markerManager>().pointStops = false;

                }
                if (select == 2)
                {
                    item1.color = new Color(0.50f, 0.92f, 1.00f);
                    if (markers[0] == null)
                    {
                        markers[0] = Instantiate(marker);
                        markers[0].transform.SetParent(transform);
                        

                    }
                    markers[0].GetComponent<markerManager>().dest[0] = stage.dests[2];
                    markers[0].GetComponent<markerManager>().color = new Color(0.3f, 0.4f, 1);
                    markers[0].GetComponent<markerManager>().numDests = 1;
                    markers[0].GetComponent<markerManager>().pointStops = false;
                }
            }

        }
        else
        {

            foreach (var item1 in GetComponentsInChildren<Light>())
            {
                item1.color = new Color(1.00f, 0.89f, 0.28f);
                if (markers[0] != null) {
                    Destroy(markers[0]);
                }
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Gas Station"))
        {
            fuelLevel = Mathf.Min(fuelLevel + Time.deltaTime * 25, maxFuel);
            DebugFueling = true;
            if (fuelLevel >= maxFuel*0.95f)
            {
                DebugFueling = false;
            }
        }
        else {
            DebugFueling = false;
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        onGround -= 4*Time.deltaTime*60;
    }
}
        