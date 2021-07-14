using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : MonoBehaviour
{
    [SerializeField]
    private string field_name;
    void Awake()
    {
        var component = GetComponent<AudioSource>();
        component.volume = PlayerPrefs.GetFloat(field_name);
    }
}
