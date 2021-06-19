using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuCanvas;

    [SerializeField]
    private GameObject mapSelectCanvas;

    void Awake()
    {
        mapSelectCanvas.SetActive(false);

        // ハイスコアの初期値を設定
    }

    public void OpenMapSelector()
    {
        mainMenuCanvas.SetActive(false);
        mapSelectCanvas.SetActive(true);
    }

    public void HideMapSelector()
    {
        mapSelectCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void Play(int mapNum)
    {
        SceneManager.LoadScene(string.Format("Map{0}Scene", mapNum));
    }

    public void OpenCharaSelector()
    {
        Debug.Log("Selector open");
    }
}
