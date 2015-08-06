using UnityEngine;
using System.Collections;

public class drownDeath : MonoBehaviour {

	public Transform Water;

	void Update () {
		if(StateMachine.Instance.State == GameState.WaterRises05){
			if(Water.position.y >= GameObject.FindGameObjectWithTag("MainCamera").transform.position.y){
				GameObject.FindGameObjectWithTag("Player").SendMessage ("ApplyLifeDamage", 1);
				Debug.Log ("Player in Distanz --> Drown Death");
			}

		}
	}
}
