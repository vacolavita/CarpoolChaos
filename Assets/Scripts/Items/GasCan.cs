using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCan : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody gasR;
    private bool canTrigger = false;
    private MeshRenderer rend;
    private Timer time;
    // Start is called before the first frame update
    void Start()
    {
        time = GetComponent<Timer>();
        rend = GetComponentInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time.reachedMilestone(0))
        {
            if (Mathf.Sin(Time.time * 30) > 0)
            {
                rend.enabled = true;
            }
            else
            {
                rend.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car") && canTrigger)
        {
            other.GetComponent<Movement>().GasCanFill();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Car")){
            canTrigger = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canTrigger = true;
        if (collision.gameObject.CompareTag("Car")) {
            collision.gameObject.GetComponent<Movement>().GasCanFill();
            Destroy(gameObject);
        }
    }
}
