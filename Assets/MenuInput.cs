using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInput : MonoBehaviour
{
    public int nav;
    public MenuController[] menus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNavigate(InputValue value)
    {
        float h = value.Get<Vector2>().x;
        float v = value.Get<Vector2>().y;
        if (value.Get<Vector2>().magnitude < 0.2) {
            nav = 0;
        }
        if (Mathf.Abs(h) >= Mathf.Abs(v))
        {
            if (Mathf.Sign(h) > 0)
            {
                foreach (var item in menus)
                {
                    item.navigate(3);
                }
            }
            else
            {
                foreach (var item in menus)
                {
                    item.navigate(2);
                }
            }
        }
        else {
            if (Mathf.Sign(h) > 0)
            {
                foreach (var item in menus)
                {
                    item.navigate(0);
                }
            }
            else
            {
                foreach (var item in menus)
                {
                    item.navigate(1);
                }
            }
        }
    }
}
