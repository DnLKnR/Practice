using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	public LevelManager levelManager;


	// Use this for initialization
	void Start () {
		//Set levelManager to the Object in the scene called LevelManager
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		//if "Player" collided into object
		if (other.name == "Player") {
			//Force player to Respawn
			levelManager.RespawnPlayer();
		}
	}
}
