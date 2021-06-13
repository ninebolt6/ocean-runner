using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PushButton : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Map1Scene");
    }

    public void OpenCharaSelector()
    {
        Debug.Log("Selector open");
    }
}
