using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoalListener : MonoBehaviour
{
    [SerializeField]
    private GameObject clearCanvas;
    [SerializeField]
    private TMP_Text scoreField;
    [SerializeField]
    private GameObject highScoreText;
    [SerializeField]
    private TMP_Text scoreString;
    
    void Awake()
    {
        clearCanvas.SetActive(false);
        highScoreText.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Goal")
        {
            Debug.Log("GOAL!");
            Time.timeScale = 0.0f;
            int score;
            bool isParsed = int.TryParse(scoreString.text, out score);

            SetScoreText(score);
            if(isHighScore(score))
            {
                highScoreText.SetActive(true);
                SetHighScore(score);
            }
            AddScore(score);
            clearCanvas.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene("StartMenuScene");
    }

    public void SetScoreText(int score)
    {
        scoreField.SetText(score.ToString());
    }

    public bool isHighScore(int score)
    {
        return GetHighScore() < score;
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "-highscore");
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "-highscore", score);
    }

    public void AddScore(int score)
    {
        int current = PlayerPrefs.GetInt("score");
        PlayerPrefs.SetInt("score", current + score);
    }
}
