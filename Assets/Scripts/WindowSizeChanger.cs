using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSizeChanger : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Screen.width < 1280)
        {
            Screen.SetResolution(1280, Screen.height, false);
        }

        if(Screen.height < 720)
        {
            Screen.SetResolution(Screen.width, 720, false);
        }
    }
}
