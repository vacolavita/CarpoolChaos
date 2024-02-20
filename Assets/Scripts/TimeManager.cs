using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private Dropdown dropDown;
    // Start is called before the first frame update
    private void Start()
    {
        //dropDown = GameObject.Find("Dropdown 1").GetComponent<Dropdown>();
        //dropDown.value = PlayerPrefs.GetInt("optionvalue");
        //dropDown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropDown); });
        DontDestroyOnLoad(gameObject);
    }
    public void HandleInputData(int val)
    {
        DontDestroyOnLoad(gameObject);
        if (val == 0)
        {
            GameModes.time = 60;
        }

        if (val == 1)
        {
            GameModes.time = 180;
        }

        if (val == 2)
        {
            GameModes.time = 300;
        }

        if (val == 3)
        {
            GameModes.time = 480;
        }

        if (val == 4)
        {
            GameModes.time = 600;
        }
    }

    public void DropdownItemSelected(Dropdown dropdown)//a delegate , a method which is invoked when the value of the dropdown is changed
    {
        switch (dropdown.value)
        {
            case 0:
                PlayerPrefs.SetInt("optionvalue", 0);
                break;
            case 1:
                PlayerPrefs.SetInt("optionvalue", 1);
                break;
            case 2:
                PlayerPrefs.SetInt("optionvalue", 2);
                break;
            case 3:
                PlayerPrefs.SetInt("optionvalue", 3);
                break;
            case 4:
                PlayerPrefs.SetInt("optionvalue", 4);
                break;
        }
    }
}
