using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    PlayerManager playerManager;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerManager = GameObject.Find("Level Manager").GetComponent<PlayerManager>();
    }

    // If player collide with power up, give power up to player, with tag Lava
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerManager.TakePowerUp(1);
            Destroy(gameObject);
        }
    }
}
