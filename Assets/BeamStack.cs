using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamStack : MonoBehaviour
{
    public Vector3[] positions;
    public int pos;
    public MeshRenderer[] rend;
    public Rigidbody r;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponentsInChildren<MeshRenderer>();
        r = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        r.MovePosition(new Vector3(Mathf.Lerp(transform.position.x, positions[pos].x, 0.03f), Mathf.Lerp(transform.position.y, positions[pos].y, 0.03f), Mathf.Lerp(transform.position.z, positions[pos].z, 0.03f)));
        foreach (var item in rend)
            item.material.color = new Color(0.9f + Mathf.Sin(Time.time*4)*0.2f, 0.9f + Mathf.Sin(Time.time * 4) * 0.2f, 0.9f + Mathf.Sin(Time.time * 4) * 0.2f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            if (collision.transform.position.x > transform.position.x)
            {
                pos = 0;
            }
            else
            {
                pos = 1;
            }
        }
    }
}
