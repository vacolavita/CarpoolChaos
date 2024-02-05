using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public int despawnRate = 60;

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
            if(parentMove.select == passengerType-1){
                transform.localPosition = transform.localPosition + new Vector3(0, 0.3f, 0);
            }
            canTrigger = false;
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
        
        if (GameModes.useLives)
        {
            StartCoroutine(DespawnPassengers());
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
                    parentMove.passengers[passengerNum - 1] = null;
                    parentMove.UpdateColor(0);
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
            GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
            transform.SetParent(other.gameObject.transform);
            parentMove = transform.parent.GetComponent<Movement>();
            for (int i = 0; i < parentMove.carryingCapacity; i++)
            {
                if (parentMove.passengers[i] == null)
                {
                    parentMove.passengers[i] = gameObject;
                    passengerNum = i+1;
                    break;
                }
            }
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





    IEnumerator DespawnPassengers()
    {
        yield return new WaitForSeconds(despawnRate);
        Destroy(gameObject);
        gameManager.LifeDrain(-0.1111111111f);
    }
}
