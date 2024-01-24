using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            Destroy(gameObject);
        }

        else
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                Debug.Log("Somebody PLEASE get this item out of the wall!!!");
                transform.position = transform.position + new Vector3(Random.Range(-16.0f, 16.0f), 1, Random.Range(-16.0f, 16.0f));
            }
        }

    }

    private void OnCollisionStay(Collision collision)
    {

    }
}
