using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider volumeSlider;

    void Start()
    {
        volumeSlider = GetComponent<Slider>();

        if (gameObject.name == "MusicSlider")
        {
            volumeSlider.value =  AudioManager.instance.GetMusicVolume();
        }
        else if (gameObject.name == "SFXSlider")
        {
            volumeSlider.value = AudioManager.instance.GetSFXVolume();
        }
    }
}
