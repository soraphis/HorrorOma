using UnityEngine;
using System.Collections;

public class explosionDeath : MonoBehaviour {
	private Transform player;
	// Use this for initialization
	void DamageRequest(){
		//player = Vector3 (GameObject.FindGameObjectWithTag ("Player").transform.position);
		Debug.Log ("DamageRequest");
		float distanz = Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, this.transform.position);
		if (distanz <= 10f) {
			GameObject.FindGameObjectWithTag("Player").SendMessage ("ApplyLifeDamage", 1);
			Debug.Log ("Player in Distanz --> Explosion Death");
		}
	}
}
