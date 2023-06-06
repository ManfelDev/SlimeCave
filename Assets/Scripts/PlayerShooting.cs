using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour 
{
	[SerializeField] private Transform firePoint;
	[SerializeField] private GameObject bulletPrefab;

	private PlayerManager playerManager;

	void Start ()
	{
		playerManager = FindObjectOfType<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	void Shoot ()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		playerManager.TakeDamage(5);
	}
}