using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("gameVolume"))
        {
            PlayerPrefs.SetFloat("gameVolume", 1);
            Load();
        }

        else
        {
            Load();
        }
    }

    // Update is called once per frame
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("gameVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("gameVolume", volumeSlider.value);
    }
}
