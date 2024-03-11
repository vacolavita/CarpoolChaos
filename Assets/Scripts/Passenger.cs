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

    Rigidbody r;
    // Start is called before the first frame update
    void Start()
    {
        mapSprite = GetComponentInChildren<SpriteRenderer>();
        mesh = GetComponentsInChildren<MeshRenderer>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawn = GameObject.Find("Spawner").GetComponent<Spawner>();
        r = GetComponent<Rigidbody>();
        foreach (var item in mesh)
        {
            item.material = passengerMats[passengerType - 1];
        }
        mapSprite.color = mesh[0].material.color;
    }

    // Update is called once per frame
    void Update()
    {
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
            mapSprite.enabled = false;
            transform.SetLocalPositionAndRotation(parentMove.PassengerPosition(passengerNum), new Quaternion());
            if (parentMove.select == passengerType - 1)
            {
                transform.localPosition = transform.localPosition + new Vector3(0, 0.3f * (1 / transform.parent.localScale.x), 0);
            }
            canTrigger = false;
        }
        else {
            //transform.rotation = Quaternion.Euler(0,transform.rotation.y,0);
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
        if (clump == null && GameModes.fragilePassengers) {
            Destroy(gameObject);
            StaticGameManager.passengersOut -= 1;
        }
    }

    private void FixedUpdate()
    {
        if (state == 0) {
            turning = 0;
            turnTimer = 0;
        }
        if (state == 1) {
            if (turning == 0 || turnTimer <= 0) {
                float sign = Mathf.Sign(turning);
                turning = Random.Range(25f, 50f) * sign * -1;
                turnTimer = Random.Range(20, 100);
            }
            turnTimer--;
            r.angularVelocity = new Vector3(0, turning, 0);
            r.velocity = transform.forward * 15;
        }
    }


    private void joinCar(Collider other) {
        if (other.GetComponent<Movement>().carryingCapacity > other.GetComponent<Movement>().currentPassengers) {
            state = 0;
            transform.SetParent(other.gameObject.GetComponent<Movement>().carMesh);
            parentMove = other.gameObject.GetComponent<Movement>();
            for (int i = 0; i < parentMove.carryingCapacity; i++)
            {
                if (parentMove.passengers[i] == null)
                {
                    parentMove.passengers[i] = gameObject;
                    passengerNum = i+1;
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
        if (!(isInCar && !callObj)) {
            if (other.gameObject.GetComponent<Destination>().destType == passengerType)
            {
                if (clump != null) {
                    clump.passengers--;
                }
                if (isInCar)
                {
                    parentMove.currentPassengers--;
                    parentMove.passengers[passengerNum - 1] = null;
                    parentMove.UpdateColor(0);
                }
                GameObject popUp = Instantiate(pop, transform.position, Quaternion.Euler(-70,0,0));
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
}
