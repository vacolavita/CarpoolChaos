using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCan : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody gasR;
    private bool canTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(GasCanDelete());
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

    IEnumerator GasCanDelete()
    {
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }
}
