using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Collections.Specialized;

public class VehicleSelected : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Vector3 pos;
    public int player;
    public int vehicle;
    Material mat;
    colorManager colors;

    // Start is called before the first frame update
    void Start()
    {
        colors = GameObject.Find("ColorManager").GetComponent<colorManager>();
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        mat.color = colors.colors[player];
    }

    public void OnSelect(BaseEventData eventData)
    {
        UnityEngine.Debug.Log(name);
        transform.position = pos;
    }

    public void OnDeselect(BaseEventData data)
    {
        transform.position = new Vector3(-45, 100f, 4.73f);
    }
}
