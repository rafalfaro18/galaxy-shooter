using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public bool gameOver = true;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject _coopPlayers;
	private UIManager _uiManager;
    public bool isCoopMode = false;
    private SpawnManager _spawnManager;
    private GameObject players = null;
    [SerializeField]
    private GameObject _pauseMenuPanel;
    [SerializeField]
    private Animator _pauseAnimator;

	// Use this for initialization
	void Start () {
		_uiManager = GameObject.Find ("Canvas").GetComponent<UIManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _pauseAnimator = GameObject.Find("Pause_Menu_Panel").GetComponent<Animator>();
        _pauseAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
	}
	
	// Update is called once per frame
	void Update () {
		//if game over is true
		if(gameOver == true){
            //if space key pressed
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
            {
                //spawn player
                if (isCoopMode == false)
                {
                    Instantiate(player, Vector3.zero, Quaternion.identity);
                } else {
                    if(players != null){
                        Destroy(players);
                    }
                    players = (GameObject)Instantiate(_coopPlayers, Vector3.zero, Quaternion.identity);
                }
                //gameover is false
                gameOver = false;
                //hide title screen
                _uiManager.HideTitleScreen();

                if (_spawnManager != null)
                {
                    _spawnManager.StartSpawnRoutines();
                }
            }

            //If esc key pressed load main menu
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Main_Menu");

            }
		}

        //if p key
        if (Input.GetKeyDown(KeyCode.P))
        {
            //show pause menu
            _pauseMenuPanel.SetActive(true);
            _pauseAnimator.SetBool("IsPaused", true);
            //pause game
            Time.timeScale = 0;
        }
	}

    public void ResumeGame()
    {
        _pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
