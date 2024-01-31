using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox2 : MonoBehaviour
{
    public GameObject gasCan;
    public GameObject tent;
    public GameObject boostPad;
    public GameObject springPad;
    private GameManager gameManager;
    public Movement car;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.hasItem)
        {
            if (car.item == 1)
            {
                gasCan.SetActive(true);
                tent.SetActive(false);
                boostPad.SetActive(false);
                springPad.SetActive(false);
            }

            if (car.item == 2)
            {
                gasCan.SetActive(false);
                tent.SetActive(false);
                boostPad.SetActive(true);
                springPad.SetActive(false);
            }

            if (car.item == 3)
            {
                gasCan.SetActive(false);
                tent.SetActive(true);
                boostPad.SetActive(false);
                springPad.SetActive(false);
            }

            if (car.item == 4)
            {
                gasCan.SetActive(false);
                tent.SetActive(false);
                boostPad.SetActive(false);
                springPad.SetActive(true);
            }
        }
        else
        {
            gasCan.SetActive(false);
            tent.SetActive(false);
            boostPad.SetActive(false);
            springPad.SetActive(false);
        }
    }
}
