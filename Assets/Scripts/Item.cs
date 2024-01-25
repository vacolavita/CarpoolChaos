using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private int itemGet;
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
            itemGet = Random.Range(1, 5);

            switch (itemGet)
            {
                case 1:
                    Debug.Log("Gas Can");
                    break;
                case 2:
                    Debug.Log("Boost Pad");
                    break;
                case 3:
                    Debug.Log("Tent");
                    break;
                case 4:
                    Debug.Log("Spring Pad");
                    break;
                default:
                    Debug.Log("Item type is null");
                    break;
            }
        }
    }

    IEnumerator ItemDelete()
    {
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }
}
