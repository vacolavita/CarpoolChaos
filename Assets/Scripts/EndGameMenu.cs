using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EndGameMenu : MonoBehaviour
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
            GameModes.useTime = true;
            GameModes.useLives = false;
        }

        if (val == 1)
        {
            GameModes.useTime = false;
            GameModes.useLives = true;
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
        }
    }
}
