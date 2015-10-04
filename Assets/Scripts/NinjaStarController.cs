using UnityEngine;
using System.Collections;

public class NinjaStarController : MonoBehaviour {

	public float speed;

	public PlayerController player;

	public GameObject enemyDeathEffect;

	public GameObject impactEffect;

	public int pointsForKill;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();

		if (player.transform.localScale.x < 0) {
			speed = -speed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D>();
		rigidBody2D.velocity = new Vector2(speed, rigidBody2D.velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);
			ScoreManager.AddPoints(pointsForKill);
		}
		Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
