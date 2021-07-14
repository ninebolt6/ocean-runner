using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InitializeScore : MonoBehaviour
{
    [SerializeField]
    private TMP_Text[] stage_highscore;

    void Awake()
    {
        if(!PlayerPrefs.HasKey("score"))
        {
            PlayerPrefs.SetInt("score", 0);
        }

        for(int i=1; i<=3; i++)
        {
            if(!PlayerPrefs.HasKey(string.Format("Map{0}Scene-highscore", i)))
            {
                PlayerPrefs.SetInt(string.Format("Map{0}Scene-highscore", i), 0);
            }
            stage_highscore[i-1].SetText(PlayerPrefs.GetInt(string.Format("Map{0}Scene-highscore", i)).ToString());
        }
    }
}
