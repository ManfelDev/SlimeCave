using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;

    // Heal player if contact is made
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerManager.GiveHealth();
            // Change power up to none
            playerManager.TakePowerUp(0);
        }
    }
}
