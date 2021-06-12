using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalListener : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Goal")
        {
            Debug.Log("GOAL!");
            SceneManager.LoadScene("StartMenuScene");
        }
    }
}
