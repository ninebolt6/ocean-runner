using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public int CoinScore;
    public int TreasureScore;
    public int OnigiriScore;
    public int RubyScore;
    public AudioClip coin_one;
    public AudioClip coin_two;
    public AudioClip coin_three;

    [SerializeField]
    private AudioSource audio_source;
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
            // play sound
            audio_source.PlayOneShot(coin_one);
        }

        if(other.gameObject.tag == "Treasure")
        {
            Debug.Log("Score get!");
            score += TreasureScore;
            UpdateScore();
            Destroy(other.gameObject);
            // play sound
            audio_source.PlayOneShot(coin_one);
        }

        if(other.gameObject.tag == "Onigiri")
        {
            Debug.Log("Score get!");
            score += OnigiriScore;
            UpdateScore();
            Destroy(other.gameObject);
            // play sound
            audio_source.PlayOneShot(coin_two);
        }

        if(other.gameObject.tag == "Ruby")
        {
            Debug.Log("Score get!");
            score += RubyScore;
            UpdateScore();
            Destroy(other.gameObject);
            // play sound
            audio_source.PlayOneShot(coin_three);
        }
    }

    void UpdateScore()
    {
        ScoreText.SetText(score.ToString());
    }
}
