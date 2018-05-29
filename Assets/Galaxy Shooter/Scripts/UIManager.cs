using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Sprite[] lives;
	public Image livesImageDisplay;
	public int score;
	public Text scoreText;
	public GameObject titleScreen;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateLives(int currentLives){
		livesImageDisplay.sprite = lives[currentLives];
	}

	public void UpdateScore(){
		score += 10;
		scoreText.text = "Score: " + score;
	}

	public void ShowTitleScreen(){
		titleScreen.SetActive (true);
	}

	public void HideTitleScreen(){
		titleScreen.SetActive (false);
		score = 0;
		scoreText.text = "Score: ";
	}
}
