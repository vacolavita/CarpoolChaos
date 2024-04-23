using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectText : MonoBehaviour
{
    public int player;
    public TextMeshProUGUI textMeshPro;
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
        }
        if (VehicleSelection.playerVehicle[player] == 1)
        {
            textMeshPro.text = "Bus";
        }
        if (VehicleSelection.playerVehicle[player] == 2)
        {
            textMeshPro.text = "Tank";
        }
        if (VehicleSelection.playerVehicle[player] == 3)
        {
            textMeshPro.text = "Sports Car";
        }

        textMeshPro.color = c.colors[VehicleSelection.playerVehicleColor[player]];
    }
}
