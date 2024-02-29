using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    // Start is called before the first frame update
    public Gradient lightColor;
    public Light lighting;
    public float startTime;
    void Start()
    {
        lighting = GetComponent<Light>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        lighting.color = lightColor.Evaluate((Time.time-startTime) / 183);
    }
}
