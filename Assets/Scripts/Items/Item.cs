using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private int itemGet;
    private GameManager gameManager;
    private ItemBox itemBox;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        GetComponent<Rigidbody>().AddTorque(new Vector3(0,5000,0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 120 * Time.deltaTime, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Car")) {
            other.GetComponent<Movement>().item = Random.Range(1, 5);
            
            
            Destroy(gameObject);
        }
    }

}
