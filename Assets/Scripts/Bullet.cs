using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	[SerializeField] private float speed = 20f;
	[SerializeField] private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		// If bullet collides with enemy game object, destroy enemy
        EnemyMovement enemy = hitInfo.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            enemy.Destroy();
            Destroy(gameObject);
        }

        // If collide with platform, destroy bullet
        if (hitInfo.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }
	}
	
}