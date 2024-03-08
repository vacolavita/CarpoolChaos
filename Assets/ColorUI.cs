using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] sprites;
    public Movement movement;
    public Image img;
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.currentPassengers == 0)
        {
            img.sprite = sprites[0];
            img.color = Color.white;
        }
        else {
            img.sprite = sprites[1];
            if (movement.select == 0) {
                img.color = Color.green;
            }
            if (movement.select == 1)
            {
                img.color = new Color(1,0.2f,0.2f);
            }
            if (movement.select == 2)
            {
                img.color = new Color(0.3f, 0.4f, 1);
            }
        }

    }
}
