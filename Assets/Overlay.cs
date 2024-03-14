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
        
    }

    // Update is called once per frame
    void Update()
    {
        image.color = new Color(1f, 1f, 1f, 0.25f);
        if (tex == null || Screen.width != tex.width || Screen.height != tex.height)
        {
            Destroy(tex);
            tex = new RenderTexture(Screen.width, Screen.height, 16);
            //tex.Create();
        }
        cam.targetTexture = tex;
        image.texture = tex;
        tex.Release();
    }
}
