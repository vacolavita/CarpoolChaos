using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIcon : MonoBehaviour
{

    public float depth;
    
    public float pulseAmount;
    public float pulseSpeed;

    public float wiggleAmount;
    public float wiggleSpeed;

    public float transparentAmount;
    public float transparentSpeed;

    public float scale = 1;

    public bool lockRotation = true;


    public Vector3 defaultScale;

    public bool scaleWithMap = true;

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        defaultScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (scaleWithMap) {
            scale *= GameObject.Find("Minimap Camera").GetComponent<Camera>().orthographicSize/59f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (lockRotation)
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, depth, transform.position.z), Quaternion.Euler(90, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleAmount));
        }
        else
        {
            transform.SetPositionAndRotation(new Vector3(transform.position.x, depth, transform.position.z), transform.rotation);
        }
        transform.localScale = new Vector3((defaultScale.x + pulseAmount + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount) * scale, (defaultScale.y + pulseAmount + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount) * scale, 0);

        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1-transparentAmount + Mathf.Sin(Time.time * transparentSpeed) * transparentAmount);
    }
}
