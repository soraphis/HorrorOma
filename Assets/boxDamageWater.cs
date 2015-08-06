using UnityEngine;
using System.Collections;

public class boxDamageWater : MonoBehaviour {
	public float damage = 20;

	void OnTriggerEnter(Collider other){
		if (other.CompareTag ("Kiste")) {
			GameObject.FindGameObjectWithTag("Player").SendMessage ("ApplyDamage", damage);

		}
	}
	
	void OnTriggerStay(Collider other){
		if (other.CompareTag ("Kiste")) {
			GameObject.FindGameObjectWithTag("Player").SendMessage ("ApplyDamage", damage);

		}
	}
}
