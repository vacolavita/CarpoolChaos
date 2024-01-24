using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    bool isInCar = false;
    bool canTrigger = true;
    int passengerNum;
    Movement parentMove;
    SpriteRenderer mapSprite;
    // Start is called before the first frame update
    void Start()
    {
        mapSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (parentMove != null) {
            if (Vector3.Distance(parentMove.transform.position, transform.position) > 4)
            {
                canTrigger = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && !isInCar && canTrigger && other.GetComponent<Movement>().carryingCapacity > other.GetComponent<Movement>().currentPassengers) {
            transform.SetParent(other.gameObject.transform);
            parentMove = transform.parent.GetComponent<Movement>();
            isInCar = true;
            canTrigger = false;
            parentMove.currentPassengers++;
            passengerNum = parentMove.currentPassengers;
            Rigidbody r = GetComponent<Rigidbody>();
            r.isKinematic = true;
        }
        if (other.gameObject.CompareTag("Car")){ canTrigger = true; }
        if (other.gameObject.CompareTag("Destination")) {
            if (isInCar) { parentMove.currentPassengers--; }
            Destroy(gameObject); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canTrigger = true;
    }
}
