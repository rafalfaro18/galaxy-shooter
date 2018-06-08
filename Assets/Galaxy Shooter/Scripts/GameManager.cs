using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public bool gameOver = true;
	public GameObject player;
	private UIManager _uiManager;
    public bool isCoopMode = false;
    private SpawnManager _spawnManager;

	// Use this for initialization
	void Start () {
		_uiManager = GameObject.Find ("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

	}
	
	// Update is called once per frame
	void Update () {
		//if game over is true
		if(gameOver == true){
			//if space key pressed
			if(Input.GetKeyDown(KeyCode.Space)){
				//spawn player
				Instantiate(player, Vector3.zero, Quaternion.identity);
				//gameover is false
				gameOver = false;
				//hide title screen
				_uiManager.HideTitleScreen();

                if(_spawnManager != null){
                  _spawnManager.StartSpawnRoutines ();
                }
			}
		}
	}
}
