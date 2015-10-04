using UnityEngine;
using System.Collections;

public class DestroyFinishedParticle : MonoBehaviour {

	private ParticleSystem thisParticleSystem;

	// Use this for initialization
	void Start () {
		thisParticleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		//If the particle system is still playing, do nothing
		if (thisParticleSystem.isPlaying) {
			return;
		}
		//else destory the particle system
		Destroy(gameObject);
	}

	void OnBecameInvisible(){
		Destroy(gameObject);
	}
}
