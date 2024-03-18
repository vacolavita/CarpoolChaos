using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private int itemGet;
    private ItemBox itemBox;
    private MeshRenderer rend;
    private Timer time;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponentInChildren<MeshRenderer>();
        time = GetComponent<Timer>();
        GetComponent<Rigidbody>().AddTorque(new Vector3(0,5000,0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 120 * Time.deltaTime, 0);
        if (time.reachedMilestone(0)) {
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Car")) {
            other.GetComponent<Movement>().item = Random.Range(1, 5);
            
            Destroy(gameObject);
        }
    }

}
