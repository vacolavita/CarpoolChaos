using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static MusicManager instance;
    public AudioClip clip;
    public string scene;
    public string clipName;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != scene) {
            GetComponent<AudioSource>().pitch = 1;
            scene = SceneManager.GetActiveScene().name;
            GameObject mus = GameObject.Find("Music");
            if (mus != null)
            {
                if (mus.GetComponent<AudioSource>().clip.name != clipName)
                {
                    clipName = mus.GetComponent<AudioSource>().clip.name;
                    GetComponent<AudioSource>().clip = mus.GetComponent<AudioSource>().clip;
                    GetComponent<AudioSource>().Play();
                }
            }
            else {
                GetComponent<AudioSource>().Stop();
            }
        }
    }
}
