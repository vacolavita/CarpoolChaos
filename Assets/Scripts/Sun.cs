using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    // Start is called before the first frame update
    public Gradient lightColor;
    public Light lighting;
    void Start()
    {
        lighting = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        lighting.color = lightColor.Evaluate(Time.time / 180);
    }
}
