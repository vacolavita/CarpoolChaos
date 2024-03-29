using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuElement : MonoBehaviour
{
    public MenuElement[] nav;
    [NonSerialized] public GameObject panel;
    public bool selected;
    void Start()
    {
        panel = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }
        else {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

}
