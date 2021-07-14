using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PauseSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseCanvas;

    void Awake()
    {
        pauseCanvas.SetActive(false);
    }

    public void Resume()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("StartMenuScene");
        Time.timeScale = 1.0f;
    }
}
