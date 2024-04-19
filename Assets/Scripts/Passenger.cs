using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    public bool isInCar = false;
    public bool canTrigger = true;
    public Clump clump;
    public int passengerNum;
    public int passengerType;
    public Material[] passengerMats;
    Movement parentMove;
    SpriteRenderer mapSprite;
    MeshRenderer[] mesh;
    private GameManager gameManager;
    private Spawner spawn;

    public GameObject pop;
    public Material plusOne;

    public int state;
    public float turning;
    public float turnTimer;

    public float jump = -1;
    public float jumpTime = 0;
    public float jumpTime2 = 10;
    public GameObject pas;
    public GameObject trail;
    GameObject tr;

    Rigidbody r;
    private bool launched;

    // Start is called before the first frame update
    void Start()
    {
        mapSprite = GetComponentInChildren<SpriteRenderer>();
        mesh = GetComponentsInChildren<MeshRenderer>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawn = GameObject.Find("Spawner").GetComponent<Spawner>();
        r = GetComponent<Rigidbody>();
        GetComponent<Collider>().material.dynamicFriction = 10;
        GetComponent<Collider>().material.staticFriction = 10;
        foreach (var item in mesh)
        {
            item.material = passengerMats[passengerType - 1];
        }
        mapSprite.color = mesh[0].material.color;
        jumpTime2 = Random.Range(2f, 6f);
        jump = -1;
    }


    // Update is called once per frame
    void Update()
    {
        if (r.velocity.magnitude < 0.2 && launched)
        {
            launched = false;
            if (tr != null) {
                tr.transform.SetParent(null);
            }
        }
        if (GameModes.peculiarPassengers && clump != null)
        {
            foreach (var item in mesh)
            {
                item.material = passengerMats[3];
            }
            mapSprite.color = mesh[0].material.color;
        }
        else
        {
            foreach (var item in mesh)
            {
                item.material = passengerMats[passengerType - 1];
            }
            mapSprite.color = mesh[0].material.color;
        }

        mapSprite.enabled = true;
        if (isInCar)
        {
            pas.transform.localPosition = new Vector3(0, -1, 0);
            pas.transform.localScale = new Vector3(1, 1, 1);
            jumpTime = 0;
            jump = 0;
            mapSprite.enabled = false;
            transform.SetLocalPositionAndRotation(parentMove.PassengerPosition(passengerNum), new Quaternion());
            if (parentMove.select == passengerType - 1)
            {
                transform.localPosition = transform.localPosition + new Vector3(0, 0.3f * (1 / transform.parent.localScale.x), 0);
            }
            canTrigger = false;
        }
        else
        {
            pas.transform.localScale = new Vector3(1.13f, 1.13f, 1.13f);
            if (jump <= -1f)
            {
                pas.transform.localPosition = new Vector3(0, -1, 0);
            }
            else
            {
                pas.transform.localPosition = new Vector3(0, Mathf.Max(pas.transform.localPosition.y + (jump * 0.7f), -1), 0);
                jump -= 2 * Time.deltaTime;
            }
        }
        if (parentMove != null)
        {
            if (Vector3.Distance(parentMove.transform.position, transform.position) > 4)
            {
                canTrigger = true;
            }
        }
        if (clump != null && clump.player != null)
        {
            joinCar(clump.player.GetComponent<Collider>());
        }
        if (Score.gameOver)
        {
            Destroy(gameObject);
        }
        jumpTime += Time.deltaTime;
        if (jumpTime >= jumpTime2)
        {
            if (r.velocity.magnitude < 0.1f)
            {
                jump = Random.Range(0.4f, 0.6f);
            }
            jumpTime = 0;
            jumpTime2 = Random.Range(2f, 6f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && !isInCar && canTrigger && clump == null)
        {
            joinCar(other);
        }
        else
        {
            if (GameModes.useLives)
            {
                StartCoroutine(DespawnPassengers());
            }
        }
        if (other.gameObject.CompareTag("Car"))
        {
            canTrigger = true;
        }
        if (other.gameObject.CompareTag("Destination"))
        {
            scorePassenger(other, false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canTrigger = true;
        if (clump == null && GameModes.fragilePassengers)
        {
            if (launched)
            {
                launched = false;
                tr.transform.SetParent(null);
            }
            Destroy(gameObject);
            StaticGameManager.passengersOut -= 1;
        }
    }

    private void FixedUpdate()
    {
        if (state == 0)
        {
            turning = 0;
            turnTimer = 0;
        }
        if (state == 1)
        {
            if (turning == 0 || turnTimer <= 0)
            {
                float sign = Mathf.Sign(turning);
                turning = Random.Range(25f, 50f) * sign * -1;
                turnTimer = Random.Range(20, 100);
            }
            turnTimer--;
            r.angularVelocity = new Vector3(0, turning, 0);
            r.velocity = transform.forward * 15;
        }
    }


    private void joinCar(Collider other)
    {
        if (launched) {
            launched = false;
            tr.transform.SetParent(null);
        }
        if (other.GetComponent<Movement>().carryingCapacity > other.GetComponent<Movement>().currentPassengers)
        {
            state = 0;
            transform.SetParent(other.gameObject.GetComponent<Movement>().carMesh);
            parentMove = other.gameObject.GetComponent<Movement>();
            for (int i = 0; i < parentMove.carryingCapacity; i++)
            {
                if (parentMove.passengers[i] == null)
                {
                    parentMove.passengers[i] = gameObject;
                    passengerNum = i + 1;
                    if (clump != null)
                    {
                        clump.passengers--;
                        clump = null;
                    }
                    break;
                }
            }
            GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.None;
            isInCar = true;
            canTrigger = false;
            parentMove.currentPassengers++;
            if (parentMove.currentPassengers == 1)
            {
                parentMove.OnScrollRight();
            }
            Rigidbody r = GetComponent<Rigidbody>();
            r.isKinematic = true;
            clump = null;
        }
    }


    public void scorePassenger(Collider other, bool callObj)
    {
        if (!(isInCar && !callObj))
        {
            if (other.gameObject.GetComponent<Destination>().destType == passengerType)
            {
                if (clump != null)
                {
                    clump.passengers--;
                }
                if (isInCar)
                {
                    parentMove.currentPassengers--;
                    parentMove.passengers[passengerNum - 1] = null;
                    parentMove.UpdateColor(0);
                }
                if (launched)
                {
                    launched = false;
                    tr.transform.SetParent(null);
                }
                GameObject popUp = Instantiate(pop, transform.position, Quaternion.Euler(-70, 0, 0));
                popUp.GetComponent<PopUp>().buildPopUp(plusOne, GetComponent<MeshRenderer>().material.color, 3, true);
                Destroy(gameObject);
                StaticGameManager.passengersOut -= 1;
                gameManager.UpdateScore(1);

            }
        }
    }



    IEnumerator DespawnPassengers()
    {
        yield return new WaitForSeconds(spawn.despawnRate);
        if (!isInCar)
        {
            Destroy(gameObject);
            StaticGameManager.passengersOut -= 1;
            gameManager.LifeDrain(-0.1111111111f);
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pushbox") && !isInCar)
        {
            Vector3 angle = new Vector3(transform.position.x - collision.gameObject.transform.position.x, 0, transform.position.z - collision.gameObject.transform.position.z).normalized;
            r.MovePosition((angle * Time.deltaTime * 5) + transform.position);
        }
    }

    public void Launch() { 
        launched = true;
        tr = Instantiate(trail, transform.position, new Quaternion());
        tr.transform.SetParent(gameObject.transform);
        if (passengerType == 1) {
            tr.GetComponent<TrailRenderer>().material.color = Color.green;
        }
        if (passengerType == 2)
        {
            tr.GetComponent<TrailRenderer>().material.color = Color.red;
        }
        if (passengerType == 3)
        {
            tr.GetComponent<TrailRenderer>().material.color = Color.blue;
        }

    }
}
