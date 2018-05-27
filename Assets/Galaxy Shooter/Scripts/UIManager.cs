﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Sprite[] lives;
	public Image livesImageDisplay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateLives(int currentLives){
		Debug.Log ("PLayer lives: "+currentLives);
		livesImageDisplay.sprite = lives[currentLives];
	}

	public void UpdateScore(){
		
	}
}
