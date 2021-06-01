using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public TextMeshProUGUI ScoreText;
    public Sprite[] HeartSprite;

    public int MaxHealth;
    private int score;
    private int health;
    private SpriteRenderer heart;

    public void GameStart()
    {
        heart = GameObject.Find("UI_Heart").GetComponent<SpriteRenderer>();
        health = MaxHealth;
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public void Heal(int amount)
    {
        if(health < MaxHealth)
        {
            health += amount;
            UpdateHealthSprite();
        }
    }

    public void UpdateHealthSprite()
    {
        heart.sprite = HeartSprite[health];
    }

    public void UpdateScoreText() 
    {
        ScoreText.SetText(score.ToString());
    }
}
