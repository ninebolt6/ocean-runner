using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : MonoBehaviour
{
    void Awake()
    {
        var component = GetComponent<AudioSource>();
        component.volume = PlayerPrefs.GetFloat("volume-bgm");
    }
}
