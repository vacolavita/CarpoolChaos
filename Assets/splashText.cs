using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class splashText : MonoBehaviour
{

    RectTransform rTransform;
    public float timer = 0;
    public bool playing = false;

    public int style = 0;
    public TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        rTransform = GetComponent<RectTransform>();
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (splashManager.splashes.Count > 0 && playing == false) {
            playing = true;
            timer = 0;
            tmp.SetText(splashManager.splashes.Peek().text);
            style = splashManager.splashes.Peek().style;
            splashManager.splashes.Dequeue();

        }
        timer += Time.deltaTime;

        if (style == 1)
        {
            tmp.fontSize = 100;
            rTransform.localPosition = new Vector3(0, Mathf.Pow((timer - 1) * 7, 3), 0);
        }
        if (style == 2)
        {
            tmp.fontSize = 70;
            rTransform.localPosition = new Vector3(Mathf.Pow((timer - 1) * 9, 3), 0, 0);
        }

        if (timer > 2) {
            playing = false;
        }
        


    }
}
