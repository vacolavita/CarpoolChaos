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
    public Image sel;
    int[] colors;
    public int player = 0;
    // Start is called before the first frame update
    void Start()
    {
        colors = new int[3];
        sel = GetComponentsInChildren<Image>()[0];
        buttons = new Image[2];
        buttons[0] = GetComponentsInChildren<Image>()[1];
        buttons[1] = GetComponentsInChildren<Image>()[2];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movement == null)
        {
            movement = GameObject.Find("Player " + player).GetComponent<Movement>();
            if (movement != null)
            {
                images = new Image[movement.carryingCapacity];
                for (int i = 0; i < movement.carryingCapacity; i++)
                {
                    Image img = Instantiate(pas).GetComponent<Image>();
                    img.rectTransform.SetParent(gameObject.GetComponent<RectTransform>());
                    img.rectTransform.localPosition = new Vector3(movement.PassengerPosition(i + 1).x * 18, movement.PassengerPosition(i + 1).z * 24, 0);
                    images[i] = img;
                }
            }
        }
       



        if (movement != null)
        {
            for (int i = 0; i < colors.Length; i++)
            {
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
                        images[i].color = new Color(images[i].color.r, images[i].color.g, images[i].color.b, 1f);
                        images[i].rectTransform.localScale = new Vector3(0.18f + (Mathf.Sin(Time.time * 10) * 0.03f), 0.18f + (Mathf.Sin(Time.time * 10) * 0.03f), 0.18f + (Mathf.Sin(Time.time * 10) * 0.03f));
                    }
                    else
                    {
                        images[i].rectTransform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    }

                }
                else
                {
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
            if (c > 0)
            {
                sel.enabled = true;
                if (movement.select == 0)
                {
                    sel.color = new Color(0.0f, 1f, 0.0f, 0.1f);
                }
                if (movement.select == 1)
                {
                    sel.color = new Color(1, 0.2f, 0.2f, 0.1f);
                }
                if (movement.select == 2)
                {
                    sel.color = new Color(0.3f, 0.4f, 1f, 0.1f);
                }
            }
            if (c > 1)
            {
                buttons[0].enabled = true;
                buttons[1].enabled = true;



                if (movement.select == 0)
                {
                    if (colors[1] > 0)
                    {
                        buttons[1].color = new Color(1, 0.2f, 0.2f, 0.8f);
                    }
                    else
                    {
                        buttons[1].color = new Color(0.3f, 0.4f, 1f, 0.8f);
                    }
                    if (colors[2] > 0)
                    {
                        buttons[0].color = new Color(0.3f, 0.4f, 1f, 0.8f);
                    }
                    else
                    {
                        buttons[0].color = new Color(1, 0.2f, 0.2f, 0.8f);
                    }
                }


                if (movement.select == 1)
                {
                    if (colors[2] > 0)
                    {
                        buttons[1].color = new Color(0.3f, 0.4f, 1f, 0.8f);
                    }
                    else
                    {
                        buttons[1].color = new Color(0.0f, 1f, 0.0f, 0.8f);
                    }
                    if (colors[0] > 0)
                    {
                        buttons[0].color = new Color(0.0f, 1f, 0.0f, 0.8f);
                    }
                    else
                    {
                        buttons[0].color = new Color(0.3f, 0.4f, 1f, 0.8f);
                    }
                }


                if (movement.select == 2)
                {
                    if (colors[0] > 0)
                    {
                        buttons[1].color = new Color(0.0f, 1f, 0.0f, 0.8f);
                    }
                    else
                    {
                        buttons[1].color = new Color(1, 0.2f, 0.2f, 0.8f);
                    }
                    if (colors[1] > 0)
                    {
                        buttons[0].color = new Color(1, 0.2f, 0.2f, 0.8f);
                    }
                    else
                    {
                        buttons[0].color = new Color(0.0f, 1f, 0.0f, 0.8f);
                    }
                }

            }
            else if (c > 0)
            {
                buttons[0].enabled = true;
                buttons[1].enabled = true;
                buttons[0].color = new Color(0.8f, 0.8f, 0.8f, 0.5f);
                buttons[1].color = new Color(0.8f, 0.8f, 0.8f, 0.5f);
            }
            else
            {
                buttons[0].enabled = false;
                buttons[1].enabled = false;
                sel.enabled = false;
            }
        }
    }
}
