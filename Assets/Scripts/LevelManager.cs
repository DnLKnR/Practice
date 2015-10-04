using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private PlayerController player;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	public int pointPenaltyOnDeath;

	public float respawnDelay;

	private float gravityScale;
	// Use this for initialization
	void Start () {
		//Get PlayerController Object that already exists in the scene
		player = FindObjectOfType<PlayerController>();
		//Store the default gravityScale
		gravityScale = player.GetComponent<Rigidbody2D>().gravityScale;
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
		//If disabling, turn gravity off, else turn it back on
		if (isEnabled) {
			rigidBody2D.gravityScale = gravityScale;
		} else {
			rigidBody2D.gravityScale = 0f;
		}
		//Stop all player movement
		rigidBody2D.velocity = Vector2.zero;
		//Disable player being controlled
		player.enabled = isEnabled;
		//Disable player form being visible
		renderer.enabled = isEnabled;
	}
}
