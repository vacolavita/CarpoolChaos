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
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
            if (gameManager.hasGasCan)
            {
                gasCanImage.SetActive(true);
                tentImage.SetActive(false) ;
                boostPadImage.SetActive(false);
                springPadImage.SetActive(false);
            }
            
            if (gameManager.hasTent)
            {
                gasCanImage.SetActive(false);
                tentImage.SetActive(true);
                boostPadImage.SetActive(false);
                springPadImage.SetActive(false);
            }

            if (gameManager.hasBoost)
            {
                gasCanImage.SetActive(false);
                tentImage.SetActive(false);
                boostPadImage.SetActive(true);
                springPadImage.SetActive(false);
            }

            if (gameManager.hasSpring)
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
