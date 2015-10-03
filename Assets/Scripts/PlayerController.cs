using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[HideInInspector] public Rigidbody2D rigidBody2D;

	public float moveSpeed;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;

	// Use this for initialization
	void Start () {
		//Instantiate rigidBody2D object
		rigidBody2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate(){

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
	// Update is called once per frame
	void Update () {
		//Input.GetKeyDown means "Key was Pressed", KeyCode.Space == "Spacebar"
		if (Input.GetKeyDown(KeyCode.Space)) {
			//Check if the player is touching the ground
			if (grounded) {
				//Call Jump function which is defined below
				Jump();
				//Set Double Jump to False
				doubleJumped = false;

			} 
			//If the player is not touching the ground
			//check if he has doubled jumped yet
			else if (!doubleJumped) {

				Jump();
				//Set Double Jump to True
				doubleJumped = true;
			}
		}
		//Input.GetKey means "Key is Pressed", KeyCode.D == "D"
		if (Input.GetKey(KeyCode.D)) {
			//move our player in the positive x-direction
			Move(moveSpeed);
		}
		//Input.GetKeyDown means "Key was Pressed", KeyCode.A means "A"
		if (Input.GetKey(KeyCode.A)) {
			//move our player in the negative x-direction
			Move(-moveSpeed);
		}

	}
	/* This function causes the player to jump when called */
	public void Jump(){
		float x = rigidBody2D.velocity.x;
		//Use the Rigidbody2D was created on our player and adjust his velocity in the y-direction
		rigidBody2D.velocity = new Vector2 (x, jumpHeight);
	}
	/* This function causes the player to move in x-direction */
	public void Move(float speed) {
		//Get the players current y vector
		float y = rigidBody2D.velocity.y;
		//Use the Rigidbody2D that was created on our player, adjust his velocity in the x-direction
		rigidBody2D.velocity = new Vector2(speed, y);
	}
}
