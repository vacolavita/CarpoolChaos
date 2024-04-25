using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectText : MonoBehaviour
{
    public int player;
    public TextMeshProUGUI textMeshPro;
    public TextMeshProUGUI desc;
    public GameObject color;
    colorManager c;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        c = color.GetComponent<colorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (VehicleSelection.playerVehicle[player] == 0) {
            textMeshPro.text = "Van";
            desc.text = "A good all-around vehicle!";
        }
        if (VehicleSelection.playerVehicle[player] == 1)
        {
            textMeshPro.text = "Bus";
            desc.text = "Big and heavy, but has a lot of space for passsengers and fuel!";
        }
        if (VehicleSelection.playerVehicle[player] == 2)
        {
            textMeshPro.text = "Tank";
            desc.text = "Ready, aim, fire! You know what this is and what this does. Have fun!";
        }
        if (VehicleSelection.playerVehicle[player] == 3)
        {
            textMeshPro.text = "Sports Car";
            desc.text = "Speedy, but it doesn't have much space, and guzzles fuel!";
        }

        textMeshPro.color = c.colors[VehicleSelection.playerVehicleColor[player]];
        desc.color = c.colors[VehicleSelection.playerVehicleColor[player]];
    }
}
