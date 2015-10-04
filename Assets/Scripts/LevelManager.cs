using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private PlayerController player;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	public int pointPenaltyOnDeath;

	public float respawnDelay;

	private CameraController camera;

	// Use this for initialization
	void Start () {
		//Get PlayerController Object that already exists in the scene
		player = FindObjectOfType<PlayerController>();
		//Get CameraController Object that already exists in the scene
		camera = FindObjectOfType<CameraController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer(){
		//Start the death and respawn as a co-routine
		StartCoroutine("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		//Start the death particle system at the given location
		Instantiate(deathParticle, player.transform.position, player.transform.rotation);
		//Turn player off
		TogglePlayer(false);
		//Take away points for dying
		ScoreManager.AddPoints(-pointPenaltyOnDeath);
		//Timer set up to wait before respawning the player
		yield return new WaitForSeconds(respawnDelay);
		//Reset the players position to their last checkpoint position
		player.transform.position = currentCheckpoint.transform.position;
		//Start the respawn particle system at the given location
		Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
		Debug.Log ("Player Respawn");
		//Turn player back on
		TogglePlayer(true);
	}

	public void TogglePlayer(bool isEnabled){
		//Get Renderer object from the player
		Renderer renderer = player.GetComponent<Renderer>();
		//Get RigidBody2D object from player
		Rigidbody2D rigidBody2D = player.GetComponent<Rigidbody2D>();
		//Stop all player movement
		rigidBody2D.velocity = Vector2.zero;
		//Enable/Disable player being controlled
		player.enabled = isEnabled;
		//Enable/Disable player form being visible
		renderer.enabled = isEnabled;
		//Enable/Disable camera following
		camera.isFollowing = isEnabled;
	}
}
