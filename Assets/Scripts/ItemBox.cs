using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemBox : MonoBehaviour
{
    private GameObject gasCanImage;
    private GameObject tentImage;
    private GameObject boostPadImage;
    private GameObject springPadImage;
    private GameManager gameManager;
    private Movement car;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        car = GameObject.Find("Car").GetComponent<Movement>();
        gasCanImage = GameObject.Find("Gas Can");
        tentImage = GameObject.Find("Tent");
        boostPadImage = GameObject.Find("Boost Pad");
        springPadImage = GameObject.Find("Spring Pad");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.hasItem)
        {
            if (car.item == 1)
            {
                gasCanImage.SetActive(true);
                tentImage.SetActive(false) ;
                boostPadImage.SetActive(false);
                springPadImage.SetActive(false);
            }
            
            if (car.item == 2)
            {
                gasCanImage.SetActive(false);
                tentImage.SetActive(true);
                boostPadImage.SetActive(false);
                springPadImage.SetActive(false);
            }

            if (car.item == 3)
            {
                gasCanImage.SetActive(false);
                tentImage.SetActive(false);
                boostPadImage.SetActive(true);
                springPadImage.SetActive(false);
            }

            if (car.item == 4)
            {
                gasCanImage.SetActive(false);
                tentImage.SetActive(false);
                boostPadImage.SetActive(false);
                springPadImage.SetActive(true);
            }
        }
        else
        {
            gasCanImage.SetActive(false);
            tentImage.SetActive(false);
            boostPadImage.SetActive(false);
            springPadImage.SetActive(false);
        }
    }
}
