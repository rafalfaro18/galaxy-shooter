﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField]
	private float _speed = 5.0f;
	[SerializeField]
	private GameObject _laserPrefab;
	[SerializeField]
	private float _fireRate = 0.25f;

	private float _canFire = 0.0f;

	// Use this for initialization
	void Start () {
		transform.position = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)){
			Shoot ();
		}
	}

	private void Shoot(){
		if( Time.time > _canFire){
			Instantiate (_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
			_canFire = Time.time + _fireRate;
		}
	}

	private void Movement(){
		float horizontalInput = Input.GetAxis ("Horizontal");
		float verticalInput = Input.GetAxis ("Vertical");
		transform.Translate (Vector3.right * _speed * horizontalInput * Time.deltaTime );
		transform.Translate (Vector3.up * _speed * verticalInput * Time.deltaTime );

		if(transform.position.y > 0){
			transform.position = new Vector3(transform.position.x, 0, 0);
		} else if(transform.position.y < -4.2f){
			transform.position = new Vector3 (transform.position.x, -4.2f, 0);
		}

		if(transform.position.x > 9.5f){
			transform.position = new Vector3 (-9.5f, transform.position.y, 0);
		} else if(transform.position.x < -9.5f){
			transform.position = new Vector3 (9.5f, transform.position.y, 0);
		}
	}
}
