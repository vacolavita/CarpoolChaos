using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditButton : MonoBehaviour
{
    private Button button;
    public GameObject credits;
    public GameObject titleScreen;
    public Button backButton;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(CreditButtonPressed);
    }

    // Update is called once per frame
    public void CreditButtonPressed()
    {
        credits.SetActive(true);
        backButton.Select();
        titleScreen.SetActive(false);
    }
}
