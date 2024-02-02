using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasCan : MonoBehaviour
{
    public float move = 5;
    private Movement car;
    private GameManager gameManager;
    private Rigidbody gasR;
    private bool canTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("Car").GetComponent<Movement>();
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
            car.GasCanFill();
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
    }

    IEnumerator GasCanDelete()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
