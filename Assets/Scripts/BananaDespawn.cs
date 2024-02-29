using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaDespawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(BananaDelete());
    }

    IEnumerator BananaDelete()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }
}
