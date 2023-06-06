using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float        maxHealth = 100;
    [SerializeField] private HealthBar    healthBar;
    [SerializeField] private GameObject   player;

    private float              currentHealth;

    // Get player's current health
    public float CurrentHealth { get => currentHealth; }
    public int PowerUp { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        // Health bar setup
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            // Go to restart screen
            SceneManager.LoadScene(2);
        }

        PowerUpEffects();
    }

    // Take damage
    public void TakeDamage(float damage)
    {            
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void GiveHealth()
    {
        currentHealth = maxHealth;

        healthBar.SetHealth(currentHealth);
    }

    public void TakePowerUp(int powerUp)
    {
        PowerUp = powerUp;
    }

    public void PowerUpEffects()
    {
        switch (PowerUp)
        {
            case 1:
                // Change color to orange
                player.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.2235294f, 0.05882353f, 1.0f);
                // Turn on script Shoot.cs
                player.GetComponent<PlayerShooting>().enabled = true;
                break;
            default:
                // Change color to the initial one
                player.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                // Turn off script Shoot.cs
                player.GetComponent<PlayerShooting>().enabled = false;
                break;
        }
    }
}