using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public int CoinScore;
    public int TreasureScore;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Coin")
        {
            Debug.Log("Score get!");
            score += CoinScore;
            UpdateScore();
            Destroy(other.gameObject);
            // play sound?
        }

        if(other.gameObject.tag == "Treasure")
        {
            Debug.Log("Score get!");
            score += TreasureScore;
            UpdateScore();
            Destroy(other.gameObject);
            // play sound?
        }
    }

    void UpdateScore()
    {
        ScoreText.SetText(score.ToString());
    }
}