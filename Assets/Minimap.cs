using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public float asp = 1;
    float width = 0.18f;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.aspect = asp;
        cam.rect = new Rect(0.41f,0,width,(Screen.width * 9.0f) / (Screen.height * 16.0f) * 0.32f);
        
    }
}
