using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DropdownMenu : MonoBehaviour
{
    const string PrefName = "optionvalue";
    private Dropdown dropDown;
    // Start is called before the first frame update

    private void Start()
    {
        dropDown = GameObject.Find("Dropdown").GetComponent<Dropdown>();
        dropDown.value = PlayerPrefs.GetInt(PrefName);
        dropDown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropDown); });
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
            case 5:
                PlayerPrefs.SetInt("optionvalue", 5);
                break;
            case 6:
                PlayerPrefs.SetInt("optionvalue", 6);
                break;
            case 7:
                PlayerPrefs.SetInt("optionvalue", 7);
                break;
            case 8:
                PlayerPrefs.SetInt("optionvalue", 8);
                break;
            case 9:
                PlayerPrefs.SetInt("optionvalue", 9);
                break;
            case 10:
                PlayerPrefs.SetInt("optionvalue", 10);
                break;
        }
    }
}