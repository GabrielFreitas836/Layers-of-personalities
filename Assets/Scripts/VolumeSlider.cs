using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider volumeSlider;

    void Start()
    {
        volumeSlider = GetComponent<Slider>();

        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
    }
}
