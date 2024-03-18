using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemBox : MonoBehaviour
{

    public Movement movement;
    public Sprite[] sprites;
    public Image image;
    public int player = 0;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponentsInChildren<Image>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        movement = GameObject.Find("Player " + player).GetComponent<Movement>();
        if (movement != null)
        {
            if (movement.item == 0)
            {
                image.enabled = false;
            }
            else
            {
                image.enabled = true;
                image.sprite = sprites[movement.item - 1];
            }
        }

    }
}
