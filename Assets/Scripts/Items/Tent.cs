using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : MonoBehaviour
{
    private Destination dest;
    // Start is called before the first frame update
    void Start()
    {
        dest = GetComponent<Destination>();
        dest.destType = Random.Range(1, 4);
        Material m = GetComponent<MeshRenderer>().material;
        if (dest.destType == 1) {
            m.color = new Color(0.3f, 1, 0.3f);
        }
        if (dest.destType == 2)
        {
            m.color = new Color(1, 0.3f, 0.3f);
        }
        if (dest.destType == 3)
        {
            m.color = new Color(0.3f,0.3f,1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(TentDelete());
    }

    public void Place()
    {

    }

    IEnumerator TentDelete()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }
}
