using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Pickable {

	public GameObject handsObject;
	public GameObject worldObject;

	/*if (worldObject.activeSelf) {
		handsObject.SetActive(false);
	}*/

	public Pickable(GameObject world, GameObject hand){
		this.handsObject = hand;
		this.worldObject = world;
		Debug.Log ("new pickable created with: " + world + " " + hand);
	}


	// toggles current state
	public void PickDrop(){
		if (handsObject.activeSelf) {
			Drop ();
			Physics.IgnoreCollision(this.worldObject.GetComponent<Collider>(),
									Player.instance.Actor.GetComponent<Collider>());
		} else {
			Pick ();
		}
	}

	private void Pick(){
		worldObject.SetActive (false);
		handsObject.SetActive (true);
	}

	private void Drop(){
		worldObject.SetActive (true);
		handsObject.SetActive (false);

		worldObject.transform.position = handsObject.transform.position;
		worldObject.transform.rotation = handsObject.transform.rotation;

		Rigidbody rb = worldObject.GetComponent<Rigidbody>();
		if(rb != null){
			Transform t = Camera.main.transform;
			rb.AddForce(t.forward * 2.8f, ForceMode.Impulse);
		}

	}

}
