using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Sprite[] lives;
	public Image livesImageDisplay;
    public int score, bestScore;
    public Text scoreText, bestText;
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

    //CheckForBestScore
    public void CheckForBestScore()
    {
        //if current score > best score
        if (score > bestScore)
        {
            //bestscore = currentScore
            bestScore = score;
            bestText.text = "Best: " + bestScore;
        }
    }

	public void ShowTitleScreen(){
		titleScreen.SetActive (true);
	}

	public void HideTitleScreen(){
		titleScreen.SetActive (false);
		score = 0;
		scoreText.text = "Score: ";
	}

    //ResumePlay
    public void ResumePlay(){
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.ResumeGame();
    }

    //BackToMainMenu
    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");
    }
}
