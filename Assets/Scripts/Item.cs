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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car")) 
        { 
            Destroy(gameObject);
        }

    }
    
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            transform.position = new Vector3(Random.Range(-16.0f, 16.0f), 1, Random.Range(-16.0f, 16.0f));
        }
    }
}
