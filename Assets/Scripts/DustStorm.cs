using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustStorm : MonoBehaviour
{
    public bool stormIsActive;
    public int stormChance;
    public ParticleSystem dustStorm;
    // Start is called before the first frame update
    void Awake()
    {
        stormIsActive = false;
        stormChance = 0;
        Storm();
    }

    // Update is called once per frame
    public void Storm()
    {
        if (!stormIsActive)
        {
            StartCoroutine(StormSelect());
        }

        if (stormChance == 9 && !stormIsActive)
        {
            stormIsActive = true;
            StopCoroutine(StormSelect());
        }
        
        if(stormIsActive)
        {
            StormStart();
        }
    }

    IEnumerator DustStormStart()
    {
        yield return new WaitForSeconds(20);
        dustStorm.Stop();
        stormIsActive = false;
    }

    IEnumerator StormSelect()
    {
        while (!stormIsActive)
        {
            stormChance = Random.Range(1, 10);
            if (stormChance == 9)
            {
                break;
            }
            yield return new WaitForSeconds(10);
        }
    }
    public void StormStart()
    {
        dustStorm.Play();
        StartCoroutine(DustStormStart());
    }
}
