using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    private PlayerManager playerManager;

    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    // Set the max health of the player
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        // Set the color of the health bar
        fill.color = gradient.Evaluate(1f);
    }
    // Set the health of the player
    public void SetHealth(float health)
    {
        slider.value = health;

        // Set the color of the heal bar
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
