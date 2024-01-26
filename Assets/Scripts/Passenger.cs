using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    bool isInCar = false;
    bool canTrigger = true;
    public Clump clump;
    int passengerNum;
    public int passengerType;
    public Material[] passengerMats;
    Movement parentMove;
    SpriteRenderer mapSprite;
    MeshRenderer[] mesh;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        mapSprite = GetComponentInChildren<SpriteRenderer>();
        mesh = GetComponentsInChildren<MeshRenderer>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
        else {
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
            canTrigger = false;
            if (Input.GetKeyDown(parentMove.drop))
            {
                isInCar = false;
                Rigidbody r = GetComponent<Rigidbody>();
                r.isKinematic = false;
                if (parentMove.launch)
                {
                    r.velocity = parentMove.launchTrajectory + new Vector3(Random.Range(-1.0f, 1.0f), 0, (Random.Range(-1.0f, 1.0f)));
                }
                else
                {
                    r.velocity = transform.forward * -3;
                }
                transform.SetParent(null);
                parentMove.currentPassengers--;
                canTrigger = false;
            }
        }
        if (parentMove != null)
        {
            if (Vector3.Distance(parentMove.transform.position, transform.position) > 4)
            {
                canTrigger = true;
            }
        }
        if (clump != null && clump.player != null) {
            joinCar(clump.player.GetComponent<Collider>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && !isInCar && canTrigger && clump == null)
        {
                joinCar(other);
        }
        if (other.gameObject.CompareTag("Car"))
        {
            canTrigger = true;
        }
        if (other.gameObject.CompareTag("Destination"))
        {
            if(other.gameObject.GetComponent<Destination>().destType == passengerType)
            {
                if (isInCar) 
                {
                    parentMove.currentPassengers--;
                }
                Destroy(gameObject);
                gameManager.UpdateScore(1);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canTrigger = true;
        if (clump == null && GameModes.fragilePassengers) {
            Destroy(gameObject);
        }
    }


    private void joinCar(Collider other) {
        if (other.GetComponent<Movement>().carryingCapacity > other.GetComponent<Movement>().currentPassengers) {
            transform.SetParent(other.gameObject.transform);
            parentMove = transform.parent.GetComponent<Movement>();
            isInCar = true;
            canTrigger = false;
            parentMove.currentPassengers++;
            passengerNum = parentMove.currentPassengers;
            Rigidbody r = GetComponent<Rigidbody>();
            r.isKinematic = true;
            clump = null;
        }
    }
}
