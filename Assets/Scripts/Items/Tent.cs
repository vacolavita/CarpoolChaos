using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : MonoBehaviour
{
    private Destination dest;
    float timer;
    float flash = 0;
    Material m;
    // Start is called before the first frame update
    void Start()
    {
        dest = GetComponent<Destination>();
        dest.destType = Random.Range(1, 4);
        m = GetComponent<MeshRenderer>().material;
        if (dest.destType == 1) {
            m.color = new Color(0.2f + flash, 1, 0.2f + flash);
        }
        if (dest.destType == 2)
        {
            m.color = new Color(1, 0.2f + flash, 0.2f + flash);
        }
        if (dest.destType == 3)
        {
            m.color = new Color(0.2f + flash ,0.2f + flash,1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 12)
        {
            flash -= Time.deltaTime * 1.4f;
            if (flash <= 0)
            {
                flash += 0.7f;
            }
        }

        if (timer >= 15) {
            Destroy(gameObject);
        }

        if (dest.destType == 1)
        {
            m.color = new Color(0.2f + flash, 1, 0.2f + flash);
        }
        if (dest.destType == 2)
        {
            m.color = new Color(1, 0.2f + flash, 0.2f + flash);
        }
        if (dest.destType == 3)
        {
            m.color = new Color(0.2f + flash, 0.2f + flash, 1);
        }
    }

}
