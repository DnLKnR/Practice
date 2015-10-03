using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;

	private PlayerController player;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float respawnDelay;

	// Use this for initialization
	void Start () {
		//Get PlayerController Object that already exists in the scene
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer(){
		//Start the death and respawn as a co-routine
		StartCoroutine("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		Instantiate(deathParticle, player.transform.position, player.transform.rotation);
		//Turn player off
		TogglePlayer(false);
		//Timer set up to wait before respawning the player
		yield return new WaitForSeconds(respawnDelay);
		//Reset the players position to their last checkpoint position
		player.transform.position = currentCheckpoint.transform.position;
		Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
		Debug.Log ("Player Respawn");
		//Turn player back on
		TogglePlayer(true);
	}

	public void TogglePlayer(bool isEnabled){
		Renderer renderer = player.GetComponent<Renderer>();
		//Disable player being controlled
		player.enabled = isEnabled;
		//Disable player form being visible
		renderer.enabled = isEnabled;
	}
}
