using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseListener : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseCanvas;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pauseCanvas.SetActive(!pauseCanvas.activeSelf);

            if(pauseCanvas.activeSelf)
            {
                Time.timeScale = 0.0f;
            }
            else 
            {
                Time.timeScale = 1.0f;
            }
        }
    }
}
