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
    }

    // Take damage
    public void TakeDamage(float damage)
    {            
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}