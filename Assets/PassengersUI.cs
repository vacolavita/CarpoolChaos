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
    // Start is called before the first frame update
    void Start()
    {
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
        for (int i = 0; i < movement.carryingCapacity; i++)
        {
            if (movement.passengers[i] != null)
            {
                images[i].enabled = true;
                images[i].sprite = passenger;
                if (movement.passengers[i].GetComponent<Passenger>().passengerType == 1)
                {
                    images[i].color = new Color(0, 1, 0, 0.5f);
                }
                if (movement.passengers[i].GetComponent<Passenger>().passengerType == 2)
                {
                    images[i].color = new Color(1, 0.2f, 0.2f, 0.5f);
                }
                if (movement.passengers[i].GetComponent<Passenger>().passengerType == 3)
                {
                    images[i].color = new Color(0.3f, 0.4f, 1, 0.5f);
                }
                if (movement.select == movement.passengers[i].GetComponent<Passenger>().passengerType - 1)
                {
                    images[i].color = new Color(images[i].color.r, images[i].color.g, images[i].color.b, 0.8f);
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
    }
}
