using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Input.GetKeyDown means "Key was Pressed", KeyCode.Space == "Spacebar"
		if (Input.GetKeyDown(KeyCode.Space)) {
			float x = GetComponent<Rigidbody2D>().velocity.x;
			//Use the Rigidbody2D was created on our player and adjust his velocity in the y-direction
			GetComponent<Rigidbody2D>().velocity = new Vector2(x, jumpHeight);
		}
		//Input.GetKey means "Key is Pressed", KeyCode.D == "D"
		if (Input.GetKey(KeyCode.D)) {
			//Get the players current y position
			float y = GetComponent<Rigidbody2D>().velocity.y;

			//Use the Rigidbody2D that was created on our player, adjust his velocity in the positive x-direction
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, y);
		}
		//Input.GetKeyDown means "Key was Pressed", KeyCode.A means "A"
		if (Input.GetKey(KeyCode.A)) {
			//Get the players current y position
			float y = GetComponent<Rigidbody2D>().velocity.y;

			//Use the Rigidbody2D that was created on our player, adjust his velocity in the negative x-direction
			GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, y);
		}

	}
}
