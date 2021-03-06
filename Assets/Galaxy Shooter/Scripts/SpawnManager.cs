﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	[SerializeField]
	private GameObject enemyShipPrefab;
	[SerializeField]
	private GameObject[] powerups;
	private GameManager _gameManager;


	// Use this for initialization
	void Start () {
		_gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartSpawnRoutines(){
		StartCoroutine (EnemySpawnRoutine ());
		StartCoroutine (PowerupSpawnRoutine ());
	}

	//create a coroutine to spawn enemy every 5 seconds
	IEnumerator EnemySpawnRoutine(){
		//create a game loop (while infinite loop) while true yield return new WaitForSeconds(5)
		while(_gameManager.gameOver == false){
			Instantiate (enemyShipPrefab, new Vector3(Random.Range(-7.0f, 7.0f), 7, 0) , Quaternion.identity );
			yield return new WaitForSeconds (5.0f);
		}
	}

	IEnumerator PowerupSpawnRoutine(){
		while (_gameManager.gameOver == false) {
			int randomPowerup = Random.Range (0, 3);
			Instantiate (powerups [randomPowerup], new Vector3 (Random.Range (-7.0f, 7.0f), 7, 0), Quaternion.identity);
			yield return new WaitForSeconds (5.0f);
		}
	}
}
