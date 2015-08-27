using UnityEngine;
using System.Collections;

public class boxOutOfRegal : MonoBehaviour {
	private Transform actor;
	private bool throwAble;
	// Use this for initialization
	void Start () {
		actor = GameObject.Find("Akteuer").transform;
		throwAble = true;
	}
	
	// Update is called once per frame
	void Update () {


		var dist = Vector3.Distance(actor.position, transform.position);
		if (throwAble) {
			if (dist < 10) {

				Wurf ();
				/*
				Vector3 posAct = actor.position + new Vector3(1F,0F,0F);
				transform.position = Vector3.MoveTowards (transform.position, posAct, 0.01F);
				transform.LookAt(actor);
				**/
			}
		}

	}

	void Wurf(){
		Rigidbody myRigidbody = GetComponent<Rigidbody> ();
		myRigidbody.AddForce(Vector3.forward * 2, ForceMode.Impulse);
		throwAble = false;
	}
}

