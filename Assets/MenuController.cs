using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public MenuElement element;
    public int info => element.info;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void navigate(int direction) {
        if (element.nav.Length > direction && element.nav[direction] != null) {
            element = element.nav[direction];
        }
    }
}
