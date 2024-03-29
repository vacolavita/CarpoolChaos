using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public MenuElement element;
    public int player;

    void Start()
    {
        element.selected = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void navigate(int direction) {
        if (element.nav.Length > direction && element.nav[direction] != null) {
            element.selected = false;
            GameObject panel = element.panel;
            element = element.nav[direction];
            element.selected = true;
            if (panel != element.panel) {
                panel.SetActive(false);
                element.panel.SetActive(true);

            }

        }
    }
}
