using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public Sprite[] HeartSprite;
    private int health;
    private GameObject character;
    private SpriteRenderer heart;
    private bool dead;
    
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Character");
        heart = GameObject.Find("UI_Heart").GetComponent<SpriteRenderer>();
        health = HeartSprite.Length - 1;
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
        health += amount;
        UpdateHealth();
    }

    void UpdateHealth()
    {
        heart.sprite = HeartSprite[health];
    }
 
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            TakeDamage(1);
        }

        if(other.gameObject.tag == "Heart")
        {
            Heal(1);
            Destroy(other.gameObject);
        }
    }
}
