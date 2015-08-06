using System.Collections;
using UnityEngine;

public class dummy : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.B)){
            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.AddExplosionForce(300*Random.value*4, new Vector3(0.85f + Random.value, 0f, -1.95f - Random.value*3), 20+Random.value*6);
        }
	}
}
