using UnityEngine;
using System.Collections;

public class omaHealth : MonoBehaviour {
	public float life = 1;
	private bool isDead = false;
	
	void ApplyLifeDamage(float lifeDamage){

			life -= 1;
			Debug.Log ("GetLifeDamage");
			life = Mathf.Max (0, life);
			if (!isDead) {
				if (life == 0) {
					isDead = true;
					GameObject.FindGameObjectWithTag("Player").GetComponent<FPController>().enabled = false;
					//GameOver
					Invoke ("GameOver", 1);
				} 
			}
	}
	
	void GameOver(){
		Application.LoadLevel (0);
	}
}
