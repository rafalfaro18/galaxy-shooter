﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
	[SerializeField]
	private float _speed = 5.0f;
	[SerializeField]
	private GameObject _laserPrefab;
	[SerializeField]
	private GameObject _tripleShotPrefab;
	[SerializeField]
	private float _fireRate = 0.25f;

	private float _canFire = 0.0f;

	public bool canTripleShot = false;
	public bool isSpeedBoostActive = false;
	[SerializeField]
	private float _speedBoost = 1.5f;

    public bool isPlayerOne = false;
    public bool isPlayerTwo = false;

	//player has 3 lives
	public int lives = 3;

	[SerializeField]
	private GameObject _explosionPrefab;

	public bool shieldsActive = false;

	[SerializeField]
	private GameObject _shieldGameObject;

	[SerializeField]
	private UIManager _uiManager;
	private GameManager _gameManager;
	private SpawnManager _spawnManager;
	private AudioSource _audioSource;

	[SerializeField]
	private GameObject[] engines;
	private int hitCount = 0;

	// Use this for initialization
	void Start () {
        
		_uiManager = GameObject.Find ("Canvas").GetComponent<UIManager> ();
		if(_uiManager!=null){
			_uiManager.UpdateLives (lives);
		}
		_gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		//_spawnManager = GameObject.Find ("Spawn_Manager").GetComponent<SpawnManager> ();
		//if(_spawnManager != null){
		//	_spawnManager.StartSpawnRoutines ();
		//}
		_audioSource = GetComponent<AudioSource> ();
		hitCount = 0;
        if (_gameManager.isCoopMode == false)
        {
            transform.position = Vector3.zero;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //if player 1
        if (isPlayerOne == true)
        {
            Movement();
#if UNITY_ANDROID
            if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("Fire")) && isPlayerOne == true)
            {
                Shoot();
            }

#elif UNITY_IOS

            if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("Fire")) && isPlayerOne == true)
            {
                Shoot();
            }
#else
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) && isPlayerOne == true)
            {
                Shoot();
            }
#endif
        }

        //if player 2
        if(isPlayerTwo == true){
            
            PlayerTwoMovement();

            if (Input.GetKeyDown(KeyCode.Return) && isPlayerTwo == true)
            {
                Shoot();
            }
        }
	}

	private void Shoot(){
		if( Time.time > _canFire){
			_audioSource.Play ();
			if(canTripleShot == true){
				Instantiate (_tripleShotPrefab, transform.position, Quaternion.identity);
			} else {
				Instantiate (_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
			}
			_canFire = Time.time + _fireRate;
		}
	}

	private void Movement(){
        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal"); //Input.GetAxis ("Horizontal");
        float verticalInput = CrossPlatformInputManager.GetAxis("Vertical"); //Input.GetAxis ("Vertical");

		float totalSpeed = 0.0f;
		if (isSpeedBoostActive == true) {
			totalSpeed = _speed * _speedBoost;
		} else {
			totalSpeed = _speed;
		}

		transform.Translate (Vector3.right * totalSpeed * horizontalInput * Time.deltaTime );
		transform.Translate (Vector3.up * totalSpeed * verticalInput * Time.deltaTime );

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

    private void PlayerTwoMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
       

        float totalSpeed = 0.0f;
        if (isSpeedBoostActive == true)
        {
            totalSpeed = _speed * _speedBoost;
        }
        else
        {
            totalSpeed = _speed;
        }


        //if hit I move up
        if (Input.GetKey(KeyCode.I))
        {
            transform.Translate(Vector3.up * totalSpeed * Time.deltaTime);
        }
        //if hit L move right
        if (Input.GetKey(KeyCode.L))
        {
            transform.Translate(Vector3.right * totalSpeed * Time.deltaTime);
        }

        //if hit K move down
        if (Input.GetKey(KeyCode.K))
        {
            transform.Translate(Vector3.down * totalSpeed * Time.deltaTime);
        }
        //if hit J move left
        if (Input.GetKey(KeyCode.J))
        {
            transform.Translate(Vector3.left * totalSpeed * Time.deltaTime);
        }


        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }

	public void Damage(){		
		//if shield on don't do the damage
		if(shieldsActive == true){
			shieldsActive = false;
			_shieldGameObject.SetActive (false);
			return;
		}

		hitCount++;
		if (hitCount == 1){
			engines [0].SetActive (true);
		} else if(hitCount == 2){
			engines [1].SetActive (true);
		}

		lives--;
		_uiManager.UpdateLives (lives);
		if(lives < 1){
			Instantiate (_explosionPrefab, transform.position, Quaternion.identity);
			_gameManager.gameOver = true;
			_uiManager.ShowTitleScreen ();
            _uiManager.CheckForBestScore();
			Destroy (this.gameObject);
		}
	}

	public void TripleShotPowerUpOn(){
		canTripleShot = true;
		StartCoroutine (TripleShotPowerDownRoutine());
	}

	public IEnumerator TripleShotPowerDownRoutine(){
		yield return new WaitForSeconds (5.0f);
		canTripleShot = false;
	}

	public void SpeedBoostPowerUpOn(){
		isSpeedBoostActive = true;
		StartCoroutine (SpeedBoostPowerDownRoutine());
	}

	public IEnumerator SpeedBoostPowerDownRoutine(){
		yield return new WaitForSeconds (5.0f);
		isSpeedBoostActive = false;
	}

	public void EnableShields(){
		shieldsActive = true;
		_shieldGameObject.SetActive (true);
	}
}
