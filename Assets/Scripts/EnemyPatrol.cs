using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;

	private bool notAtEdge;
	public Transform edgeCheck;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Check if the enemy has hit a wall
		hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
		//Check if the enemy has near an edge
		notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);
		//if the enemy is hitting the wall or near an edge, reverse direction
		if (hittingWall || !notAtEdge) {
			moveRight = !moveRight;
		}

		Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D>();
		if (moveRight) {
			transform.localScale = new Vector3(-1f,1f,1f);
			rigidBody2D.velocity = new Vector2 (moveSpeed, rigidBody2D.velocity.y);
		} else {
			transform.localScale = new Vector3(1f,1f,1f);
			rigidBody2D.velocity = new Vector2 (-moveSpeed, rigidBody2D.velocity.y);
		}
	}
}
