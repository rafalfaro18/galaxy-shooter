using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadSinglePlayer(){
        Debug.Log("Single Player Loading...");
        //Load Scene 1 -- single player scene
        SceneManager.LoadScene(1);
    }

    public void LoadCoOp()
    {
        Debug.Log("Co-Op Loading...");
        //Load Scene 2 -- Co-Op scene
        SceneManager.LoadScene(2);
    }
}
