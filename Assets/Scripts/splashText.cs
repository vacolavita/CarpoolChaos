using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class splashText : MonoBehaviour
{

    RectTransform rTransform;
    public float timer = 0;
    public bool playing = false;

    public int style = 0;
    public TextMeshProUGUI tmp;
    public AudioSource[] audioSources;
    public bool sound = false;
    // Start is called before the first frame update
    void Start()
    {
        rTransform = GetComponent<RectTransform>();
        tmp = GetComponent<TextMeshProUGUI>();
        audioSources = GetComponents<AudioSource>();
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
            sound = false;
            if (style == 2) {
                audioSources[0].Play();
            }
            if (style == 1)
            {
                audioSources[2].Play();
            }

        }
        timer += Time.deltaTime * 1.1f;
        if (splashManager.splashes.Count > 0) {
            timer += Time.deltaTime * 0.5f * splashManager.splashes.Count;
        }
        if (splashManager.splashes.Count > 4)
        {
            timer += Time.deltaTime * 0.2f * splashManager.splashes.Count;
        }

        if (style == 1)
        {
            tmp.fontSize = 100;
            rTransform.localPosition = new Vector3(0, Mathf.Pow((timer - 1) * 7, 3), 0);
        }
        if (style == 2)
        {
            tmp.fontSize = 60;
            rTransform.localPosition = new Vector3(Mathf.Pow((timer - 1) * 9, 3), 0, 0);
            if (!sound && timer > 1) { 
                sound = true;
                audioSources[1].Play();
            }
        }

        if (timer > 2) {
            playing = false;
        }
        


    }
}
