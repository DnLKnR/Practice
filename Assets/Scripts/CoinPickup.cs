using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public int pointsToAdd;

	void OnTriggerEnter2D(Collider2D other){
		//If something that wasn't the player hits the coin, do nothing
		if (other.GetComponent<PlayerController>() == null) {
			return;
		}
		//Add the points to the score
		ScoreManager.AddPoints(pointsToAdd);
		//Destory the coin
		Destroy(gameObject);
	}
}
