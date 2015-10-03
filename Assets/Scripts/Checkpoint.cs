using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public LevelManager levelManager;

	private PlayerController player;
	
	// Use this for initialization
	void Start () {
		//Get PlayerController Object that already exists in the scene
		player = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		//if "Player" collided into object
		if (other.name == "Player") {
			//Store new checkpoint that was collided with
			levelManager.currentCheckpoint = gameObject;
			Debug.Log ("Activated Checkpoint " + transform.position);
			
		}
	}
}
