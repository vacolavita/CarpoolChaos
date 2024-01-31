using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private int itemGet;
    private GameManager gameManager;
    private ItemBox itemBox;
    public bool hasItem;
    private GasCan gasCan;
    public bool hasGasCan;
    public bool hasBoost;
    public bool hasTent;
    public bool hasSpring;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        GetComponent<Rigidbody>().AddTorque(new Vector3(0,5000,0));
        gasCan = GetComponent<GasCan>();
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
            if (other.GetComponent<Movement>().item == 0) 
            {
                other.GetComponent<Movement>().item = Random.Range(1, 5);
            }
            gameManager.hasItem = true;
            Destroy(gameObject);
        }
    }

    IEnumerator ItemDelete()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
