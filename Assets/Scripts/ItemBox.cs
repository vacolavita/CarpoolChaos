using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemBox : MonoBehaviour
{
    public GameObject gasCanImage;
    public GameObject tentImage;
    public GameObject boostPadImage;
    public GameObject springPadImage;
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
                gasCanImage.SetActive(true);
                tentImage.SetActive(false) ;
                boostPadImage.SetActive(false);
                springPadImage.SetActive(false);
            }
            
            if (car.item == 2)
            {
                gasCanImage.SetActive(false);
                tentImage.SetActive(false);
                boostPadImage.SetActive(true);
                springPadImage.SetActive(false);
            }

            if (car.item == 3)
            {
                gasCanImage.SetActive(false);
                tentImage.SetActive(true);
                boostPadImage.SetActive(false);
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
