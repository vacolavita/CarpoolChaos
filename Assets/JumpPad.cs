using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public GameObject platform;
    public float time = 99;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0.3f)
        {
            platform.transform.localPosition = new Vector3(44.2f, 0, 72.4f);
        }
        else if (time < 0.15f)
        {
            platform.transform.localPosition = new Vector3(44.2f, time * 150, 72.4f);
        }
        else {
            platform.transform.localPosition = new Vector3(44.2f, (0.3f-time) * 150, 72.4f);
        }
        time += Time.deltaTime;
    }

    public void Trigger()
    {
        time = 0;
    }
}
