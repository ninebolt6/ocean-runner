using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalListener : MonoBehaviour
{
    [SerializeField]
    private GameObject goalCanvas;

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Debug.Log("GOAL!");
        SceneManager.sceneLoaded += ResultSceneLoaded;
        SceneManager.LoadScene("ResultScene");
    }

    private void ResultSceneLoaded(Scene next, LoadSceneMode mode)
    {
        
    }
}
