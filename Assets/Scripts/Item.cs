using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddTorque(new Vector3(0,5000,0));
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ItemDelete());
        transform.Rotate(0, 180 * Time.deltaTime, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ItemDelete()
    {
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }
}
