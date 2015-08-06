using UnityEngine;
using System.Collections;

public class electricalShockDeath : MonoBehaviour {

	public Transform Water;

	void Update () {
		if(StateMachine.Instance.State == GameState.WaterBoiler04){
			if(Water.position.y >= 0.90f){
				GameObject.FindGameObjectWithTag("Player").SendMessage ("ApplyLifeDamage", 1);
				Debug.Log ("Player in Distanz --> Electrical Shock Death");
			}
			
		}
	}
}
