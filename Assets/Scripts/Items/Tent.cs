using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : MonoBehaviour
{
    private Destination dest;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        dest = GetComponent<Destination>();
        dest.destType = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Place()
    {

    }
}
