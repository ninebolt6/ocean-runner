using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverCanvas;
    public Sprite[] HeartSprite;
    public int MaxHealth;
    private int health;
    private GameObject character;
    private SpriteRenderer heart;
    private bool dead = false;
    
    void Awake()
    {
        gameOverCanvas.SetActive(false);
    }

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
            // 必要ない？
        }
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealth();

        if(health <= 0)
        {
            dead = true;
            Time.timeScale = 0.0f;
            gameOverCanvas.SetActive(true);
            Debug.Log("GAME OVER!");
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

    public void Retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MapScene");
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartMenuScene");
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

        if(other.gameObject.tag == "Void")
        {
            TakeDamage(health);
            Debug.Log("Void dead");
        }
    }
}
