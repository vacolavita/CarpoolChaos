using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelMeter : MonoBehaviour
{
    public Movement movement;
    public Image fuelFill;
    public Image UI;
    // Start is called before the first frame update
    void Start()
    {
        UI = GetComponentsInChildren<Image>()[0];
        UI.color = movement.paint;
        fuelFill = GetComponentsInChildren<Image>()[2];
    }

    // Update is called once per frame
    void Update()
    {
        fuelFill.fillAmount = movement.fuelLevel * 0.0097f + 0.015f;
        float f = Mathf.Clamp(Mathf.Min(movement.fuelLevel,50)-30, 0, 50)*0.028f;
        fuelFill.color = new Color(0.87f, 0.2f+f, 0.2f);

    }
}
