using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelMeter : MonoBehaviour
{
    public Movement movement;
    public Image fuelFill;
    public Image fuelDif;
    public Image UI;
    public float fuel;
    public float time = 0;
    public int desync = 0;
    // Start is called before the first frame update
    void Start()
    {
        UI = GetComponentsInChildren<Image>()[0];
        UI.color = movement.paint;
        fuelDif = GetComponentsInChildren<Image>()[2];
        fuelFill = GetComponentsInChildren<Image>()[3];
        fuel = movement.fuelLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(movement.fuelLevel - fuel) >= 3) {
            time = 0.6f;
                
                if (movement.fuelLevel > fuel) {
                    if (desync == 0) { fuelDif.fillAmount = movement.fuelLevel * 0.0097f + 0.015f; }
                    desync = 1;

                } else
                {
                    if (desync == 0) { fuelFill.fillAmount = fuel * 0.0097f + 0.015f; }
                    desync = 2;
                }
        }
        fuel = movement.fuelLevel;
        if (desync == 0)
        {
            fuelFill.fillAmount = fuel * 0.0097f + 0.015f;
            fuelDif.fillAmount = fuel * 0.0097f + 0.015f;
        }
        else {
            time -= Time.deltaTime;

            if (desync == 2)
            {
                fuelFill.fillAmount = fuel * 0.0097f + 0.015f;
                if (time <= 0)
                {
                    fuelDif.fillAmount -= Time.deltaTime * 0.3f;
                    if (fuelDif.fillAmount <= fuelFill.fillAmount)
                    {
                        fuelDif.fillAmount = fuelFill.fillAmount;
                        desync = 0;
                    }
                }
            }
            else {
                fuelDif.fillAmount = fuel * 0.0097f + 0.015f;
                if (time <= 0)
                {
                    fuelFill.fillAmount += Time.deltaTime * 0.3f;
                    if (fuelDif.fillAmount <= fuelFill.fillAmount)
                    {
                        fuelFill.fillAmount = fuelDif.fillAmount;
                        desync = 0;
                    }
                }
            }
        }

        float f = Mathf.Clamp(Mathf.Min(movement.fuelLevel,50)-30, 0, 50)*0.028f;
        fuelFill.color = new Color(0.87f, 0.2f+f, 0.2f);


    }
}
