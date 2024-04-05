using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject item;
    bool activated = false;
    ParticleSystem p;
    Collider[] col;
    Material m;
    void Start()
    {
        p = GetComponentInChildren<ParticleSystem>();
        col = GetComponents<Collider>();
        m = GetComponentInChildren<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car") && !activated)
        {



            GameObject i = Instantiate(item, transform.position + new Vector3(1, 3, -5), new Quaternion());
            Rigidbody r = i.GetComponent<Rigidbody>();
            if (collision.transform.position.x > transform.position.x)
            {
                i.transform.position += new Vector3(-1, 0, 0);
                r.velocity += new Vector3(-13, 2, 0);
            }
            else
            {
                i.transform.position += new Vector3(1, 0, 0);
                r.velocity += new Vector3(13, 2, 0);
            }
            activated = true;
            col[0].enabled = false;
            p.Stop();
            p.Clear();
            m.color = new Color(0.8f, 0.8f, 0.8f);
            m.SetFloat("_Glossiness", 0.6f);

        }
    }

    public void Activate()
    {
        p.Play();
        activated = false;
        col[0].enabled = true;
        m.color = new Color(1f, 1f, 1f);
        m.SetFloat("_Glossiness", 1);
    }
}
