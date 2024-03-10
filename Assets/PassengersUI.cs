using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassengersUI : MonoBehaviour
{
    public Movement movement;
    public Sprite passenger;
    public Image[] images;
    public Image pas;
    public Image[] buttons;
    int[] colors;
    // Start is called before the first frame update
    void Start()
    {
        colors = new int[3];
        buttons = new Image[2];
        buttons[0] = GetComponentsInChildren<Image>()[0];
        buttons[1] = GetComponentsInChildren<Image>()[1];
        images = new Image[movement.carryingCapacity];
        for (int i = 0; i < movement.carryingCapacity; i++) {
            Image img = Instantiate(pas).GetComponent<Image>();
            img.rectTransform.SetParent(gameObject.GetComponent<RectTransform>());
            img.rectTransform.localPosition = new Vector3(movement.PassengerPosition(i+1).x * 15, movement.PassengerPosition(i+1).z * 20, 0) ;
            images[i] = img;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < colors.Length; i++) {
            colors[i] = 0;
        }
        for (int i = 0; i < movement.carryingCapacity; i++)
        {
            if (movement.passengers[i] != null)
            {
                images[i].enabled = true;
                images[i].sprite = passenger;
                if (movement.passengers[i].GetComponent<Passenger>().passengerType == 1)
                {
                    images[i].color = new Color(0, 1, 0, 0.4f);
                    colors[0]++;
                }
                if (movement.passengers[i].GetComponent<Passenger>().passengerType == 2)
                {
                    images[i].color = new Color(1, 0.2f, 0.2f, 0.4f);
                    colors[1]++;
                }
                if (movement.passengers[i].GetComponent<Passenger>().passengerType == 3)
                {
                    images[i].color = new Color(0.3f, 0.4f, 1, 0.4f);
                    colors[2]++;
                }
                if (movement.select == movement.passengers[i].GetComponent<Passenger>().passengerType - 1)
                {
                    images[i].color = new Color(images[i].color.r, images[i].color.g, images[i].color.b, 0.9f);
                    images[i].rectTransform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                }
                else {
                    images[i].rectTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                }

            }
            else {
                images[i].enabled = false;
            }
        }
        int c = 0;
        foreach (var item in colors)
        {
            if (item > 0)
            {
                c++;
            }
        }
        if (c > 1)
        {
            buttons[0].enabled = true;
            buttons[1].enabled = true;




            if (movement.select == 0) {
                if (colors[1] > 0)
                {
                    buttons[1].color = new Color(1, 0.2f, 0.2f);
                }
                else {
                    buttons[1].color = new Color(0.3f, 0.4f, 1f);
                }
                if (colors[2] > 0)
                {
                    buttons[0].color = new Color(0.3f, 0.4f, 1f);
                }
                else
                {
                    buttons[0].color = new Color(1, 0.2f, 0.2f);
                }
            }


            if (movement.select == 1)
            {
                if (colors[2] > 0)
                {
                    buttons[1].color = new Color(0.3f, 0.4f, 1f);
                }
                else
                {
                    buttons[1].color = new Color(0.0f, 1f, 0.0f);
                }
                if (colors[0] > 0)
                {
                    buttons[0].color = new Color(0.0f, 1f, 0.0f);
                }
                else
                {
                    buttons[0].color = new Color(0.3f, 0.4f, 1f);
                }
            }


            if (movement.select == 2)
            {
                if (colors[0] > 0)
                {
                    buttons[1].color = new Color(0.0f, 1f, 0.0f);
                }
                else
                {
                    buttons[1].color = new Color(1, 0.2f, 0.2f);
                }
                if (colors[1] > 0)
                {
                    buttons[0].color = new Color(1, 0.2f, 0.2f);
                }
                else
                {
                    buttons[0].color = new Color(0.0f, 1f, 0.0f);
                }
            }

        }
        else
        {
            buttons[0].enabled = false;
            buttons[1].enabled = false;
        }
    }
}
