using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	[SerializeField]
	private GameObject enemyShipPrefab;
	[SerializeField]
	private GameObject[] powerups;


	// Use this for initialization
	void Start () {
		StartCoroutine (EnemySpawnRoutine ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//create a coroutine to spawn enemy every 5 seconds
	private IEnumerator EnemySpawnRoutine(){
		//create a game loop (while infinite loop) while true yield return new WaitForSeconds(5)
		while(true){
			Instantiate (enemyShipPrefab, new Vector3(Random.Range(-7.0f, 7.0f), 7, 0) , Quaternion.identity );
			yield return new WaitForSeconds (5.0f);
		}
	}
}
