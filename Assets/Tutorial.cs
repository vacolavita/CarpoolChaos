using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public float timer = 0;
    public TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 4) {
            tmp.text = "Use the [Left Stick] to drive to passengers to pick them up!";
        }
        if (timer >= 12)
        {
            tmp.text = "Get passengers to the destination of their color to score them!";
        }
        if (timer >= 20)
        {
            tmp.text = "Press [B] to launch passengers if you have fuel!\nPassengers can be launched over fences.";
        }
        if (timer >= 28)
        {
            tmp.text = "Press [A] to drop passengers!";
        }
        if (timer >= 36)
        {
            tmp.text = "Press [Y] to use an item, if you've picked one up!";
        }
        if (timer >= 44)
        {
            tmp.text = "Use [L/R] to select a color of passenger in your car to launch or drop!";
        }
        if (timer >= 52)
        {
            tmp.text = "If fuel is low, go to the Gas Station!";
        }
        if (timer >= 60)
        {
            tmp.text = "When in doubt, follow the arrows and watch the minimap!";
        }
        if (timer >= 68)
        {
            tmp.text = "Work together and get a high score!";
        }
        if (timer >= 76)
        {
            tmp.text = "";
        }
    }
}
