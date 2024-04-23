using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColorChanger : MonoBehaviour
{
    int playerAssignment;
    // Start is called before the first frame update
    void Start()
    {
        playerAssignment = GetComponent<PlayerAssignment>().num;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnColorUp() {
        if (SceneManager.GetActiveScene().name == "VehicleSelect") {
            VehicleSelection.playerVehicleColor[playerAssignment]--;
            if (VehicleSelection.playerVehicleColor[playerAssignment] < 0) {
                VehicleSelection.playerVehicleColor[playerAssignment] = 19;
            }
        }
    }

    public void OnColorDown()
    {
        if (SceneManager.GetActiveScene().name == "VehicleSelect")
        {
            VehicleSelection.playerVehicleColor[playerAssignment]++;
            if (VehicleSelection.playerVehicleColor[playerAssignment] > 19)
            {
                VehicleSelection.playerVehicleColor[playerAssignment] = 0;
            }
        }
    }

    public void OnVehicleLeft()
    {
        if (SceneManager.GetActiveScene().name == "VehicleSelect")
        {
            VehicleSelection.playerVehicle[playerAssignment]--;
            if (VehicleSelection.playerVehicle[playerAssignment] < 0)
            {
                VehicleSelection.playerVehicle[playerAssignment] = 3;
            }
        }
    }

    public void OnVehicleRight()
    {
        if (SceneManager.GetActiveScene().name == "VehicleSelect")
        {
            VehicleSelection.playerVehicle[playerAssignment]++;
            if (VehicleSelection.playerVehicle[playerAssignment] > 3)
            {
                VehicleSelection.playerVehicle[playerAssignment] = 0;
            }
        }
    }


}
