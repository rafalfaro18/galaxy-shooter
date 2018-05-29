using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Sprite[] lives;
	public Image livesImageDisplay;
	public int score;
	public Text scoreText;
	public bool hasGameStarted = false;
	[SerializeField]
	private GameObject SpawnManager;
	[SerializeField]
	private Image titleImage;
	public bool playerAlive;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//create a global variable hasGameStarted?
		//space key starts the game:
		if(Input.GetKeyDown(KeyCode.Space) && hasGameStarted == false){
			//spawns player (player must be a prefab)
			hasGameStarted = true;
			SpawnManager.GetComponent<SpawnManager>().SpawnPlayer();
			playerAlive = true;
			//turn off the title
			titleImage.enabled = false;
		}
		//when player dies
		if(hasGameStarted == true && playerAlive == false ){
			//clear the score
			score = 0;
			scoreText.text = "Score: ";
			//bring back the title
			titleImage.enabled = true;
			//re-start when press space key
			//hasGameStarted = false
			hasGameStarted = false;
		}
	}

	public void UpdateLives(int currentLives){
		livesImageDisplay.sprite = lives[currentLives];
	}

	public void UpdateScore(){
		score += 10;
		scoreText.text = "Score: " + score;
	}


}
