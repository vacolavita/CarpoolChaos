using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInput : MonoBehaviour
{
    public int nav = -1;
    public MenuController[] menus;
    // Start is called before the first frame update
    void Start()
    {
        menus = new MenuController[5];
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(nav);
    }

    public void OnNavigate(InputValue value)
    {
        
        float h = value.Get<Vector2>().x;
        float v = value.Get<Vector2>().y;
        if (value.Get<Vector2>().magnitude < 0.2)
        {
            nav = -1;
        }
        else
        {
            if (Mathf.Abs(h) >= Mathf.Abs(v))
            {
                if (Mathf.Sign(h) > 0)
                {
                    if (nav != 3)
                    {
                        nav = 3;
                        foreach (var item in menus)
                        {
                            if (item != null)
                                item.navigate(3);
                        }
                    }
                }
                else
                {
                    if (nav != 2)
                    {
                        nav = 2;
                        foreach (var item in menus)
                        {
                            if(item != null)
                                item.navigate(2);
                        }
                    }
                }
            }
            else
            {
                if (Mathf.Sign(v) > 0)
                {
                    if (nav != 0)
                    {
                        nav = 0;
                        foreach (var item in menus)
                        {
                            if (item != null)
                                item.navigate(0);
                        }
                    }
                }
                else
                {
                    if (nav != 1)
                    {
                        nav = 1;
                        foreach (var item in menus)
                        {
                            if (item != null)
                                item.navigate(1);
                        }
                    }
                }
            }
        }
    }
}
