using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Collections.Specialized;

public class VehicleSelected : MonoBehaviour
{
    public Vector3 pos;
    public int player;
    public int vehicle;
    public int matnum;
    Material mat;
    colorManager colors;

    // Start is called before the first frame update
    void Start()
    {
        colors = GameObject.Find("ColorManager").GetComponent<colorManager>();
        mat = GetComponent<MeshRenderer>().materials[matnum];
    }

    // Update is called once per frame
    void Update()
    {
        mat.color = colors.colors[VehicleSelection.playerVehicleColor[player]];
        if (VehicleSelection.playerVehicle[player] == vehicle)
        {
            transform.position = pos;
        }
        else { 
            transform.position = pos + new Vector3(0,100,0);
        }
    }
}
