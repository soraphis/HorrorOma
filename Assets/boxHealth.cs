using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class boxHealth : MonoBehaviour {
	public float health = 100;
	private bool damageable = true;
	private bool isDead = false;
	
	void ApplyDamage(float damage){
		if (damageable) {
			health -= damage;
			Debug.Log ("GetDamage");
			health = Mathf.Max (0, health);
			if (!isDead) {
				if (health == 0) {
					isDead = true;
					GameObject.FindGameObjectWithTag("Player").GetComponent<FPController>().enabled = false;
					//GameOver
					Invoke ("GameOver", 1);
				} 
				damageable = false;
				Invoke ("ResetDamageable", 1);
			}
		}
	}

	void GameOver(){
		Application.LoadLevel (0);
	}

	void ResetDamageable(){
		damageable = true;
	}	
}
