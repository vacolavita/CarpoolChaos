using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody body;
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.MovePosition(transform.position + new Vector3(0, 0, 0.3f));
        if (transform.position.z > 350) {
            transform.position += new Vector3(0, 0, -500);
        }
    }
}
