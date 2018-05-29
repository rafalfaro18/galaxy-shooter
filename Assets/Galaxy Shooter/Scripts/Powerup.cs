﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
	[SerializeField]
	private float _speed = 3.0f;
	[SerializeField]
	private int powerupID;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.down * _speed * Time.deltaTime);
		if(transform.position.y < -7){
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			Player player = other.GetComponent<Player> ();
			if (player != null) {
				if (powerupID == 0) {
					player.TripleShotPowerUpOn ();
				} else if (powerupID == 1) {
					player.SpeedBoostPowerUpOn ();
				} else if (powerupID == 2) {
					player.EnableShields();
				}
				Destroy (this.gameObject);
			}
		}
	}
}
