using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(BoostPadDelete());
    }

    IEnumerator BoostPadDelete()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
