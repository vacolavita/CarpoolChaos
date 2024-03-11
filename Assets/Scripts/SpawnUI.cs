using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUI : MonoBehaviour
{
    Spawner spawn;
    Image img;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.Find("Spawner").GetComponent<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        img = GetComponent<Image>();
        img.fillAmount = (spawn.timer / spawn.spawnTimeAdjusted) * 0.94f + 0.03f;
        if (spawn.rush) {
            img.color = new Color(1,0.5f,0.5f);
        }
    }
}
