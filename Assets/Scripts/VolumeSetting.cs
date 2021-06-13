using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField]
    private Slider bgmSlider;
    [SerializeField]
    private Slider seSlider;

    void Awake()
    {
        if(!PlayerPrefs.HasKey("volume-bgm"))
        {
            PlayerPrefs.SetFloat("volume-bgm", 0.25f);
        }

        if(!PlayerPrefs.HasKey("volume-se"))
        {
            PlayerPrefs.SetFloat("volume-se", 0.25f);
        }

        bgmSlider.value = PlayerPrefs.GetFloat("volume-bgm");
        seSlider.value = PlayerPrefs.GetFloat("volume-se");
    }

    public void SetBgmVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume-bgm", volume);
    }

    public void SetSoundEffectVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume-se", volume);
    }
}
