using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	//variable for speed
	[SerializeField]
	private float _speed = 5.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//move down
		transform.Translate (Vector3.down * _speed * Time.deltaTime );
		//when off screen on bottom
		if(transform.position.y < -7.0f){
			//respawn back on top with a new x position between the bounds of the screen
			float randomX = Random.Range(-7.0f, 7.0f);
			transform.position = new Vector3(randomX, 7.0f, transform.position.z);
		}
	}

	private void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Laser" ){
			//if enemy colides the laser, the laser and the enemy are destroyed
			Destroy(this.gameObject);
			if(other.transform.parent != null){
				Destroy (other.transform.parent.gameObject);
			}
			Destroy (other.gameObject);
		} else if (other.tag == "Player") {
			//if colides with player
			Player player = other.GetComponent<Player>();
			//gets destroyed and the player loses one life (Enemy substracts the life)
			if(player != null){
				player.Damage ();
			}
			Destroy (this.gameObject);
		} 

	}
}
