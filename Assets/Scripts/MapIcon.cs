using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIcon : MonoBehaviour
{

    public int depth;
    
    public float pulseAmount;
    public float pulseSpeed;

    public float wiggleAmount;
    public float wiggleSpeed;

    public float scale = 1;

    public Vector3 defaultScale;
    // Start is called before the first frame update
    void Start()
    {
        defaultScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(new Vector3(transform.position.x,depth,transform.position.z), Quaternion.Euler(90,0, 90 + Mathf.Sin(Time.time * wiggleSpeed) * wiggleAmount));
        transform.localScale = new Vector3((defaultScale.x + pulseAmount + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount) * scale, (defaultScale.y + pulseAmount + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount) * scale, 0);
    }
}
