using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour
{
    Camera cam;
    public RawImage image;
    RenderTexture tex;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.targetTexture = tex;
        image.texture = tex;
        image.color = new Color(1, 1, 1, 0.1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(tex);
        tex = new RenderTexture(Screen.width, Screen.height, 16);
        tex.Create();
        cam.targetTexture = tex;
        image.texture = tex;
        tex.Release();
    }
}
