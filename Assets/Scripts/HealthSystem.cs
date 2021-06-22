using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public Sprite[] HeartSprite;
    public int MaxHealth;
    public AudioClip heal_sound;
    public AudioClip fall_sound;
    public AudioClip damage_sound;

    [SerializeField]
    private GameObject gameOverCanvas;
    private int health;
    private GameObject character;
    private SpriteRenderer heart;
    [SerializeField]
    private AudioSource audio_source;
    
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
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateHealth();

        if(health <= 0)
        {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            audio_source.PlayOneShot(damage_sound);
            TakeDamage(1);
        }

        if(other.gameObject.tag == "Heart")
        {
            Heal(1);
            audio_source.PlayOneShot(heal_sound);
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Void")
        {
            TakeDamage(health);
            audio_source.PlayOneShot(fall_sound);
            Debug.Log("Void dead");
        }
    }
}
