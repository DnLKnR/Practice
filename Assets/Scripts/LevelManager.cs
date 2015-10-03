using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private PlayerController player;

	// Use this for initialization
	void Start () {
		//Get PlayerController Object that already exists in the scene
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer(){
		Debug.Log ("Player Respawn");
		//Reset the players position to their current checkpoint position
		player.transform.position = currentCheckpoint.transform.position;
	}
}
