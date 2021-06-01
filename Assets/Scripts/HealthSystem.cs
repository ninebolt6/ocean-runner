using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public Sprite[] HeartSprite;
    public int MaxHealth;
    private int health;
    private GameObject character;
    private SpriteRenderer heart;
    private bool dead;
    
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Character2D");
        heart = GameObject.Find("UI_Heart").GetComponent<SpriteRenderer>();
        health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(dead)
        {
            Debug.Log("GAME OVER!");
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealth();

        if(health <= 0)
        {
            dead = true;
            SceneManager.LoadScene("StartMenuScene");
        }
    }

    public void Heal(int amount)
    {
        if((health + amount) <= MaxHealth)
        {
            health += amount;
            UpdateHealth();
        }
    }

    void UpdateHealth()
    {
        heart.sprite = HeartSprite[health];
    }
 
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Hit!");
            TakeDamage(1);
        }

        if(other.gameObject.tag == "Heart")
        {
            Heal(1);
            Destroy(other.gameObject);
        }
    }
}
