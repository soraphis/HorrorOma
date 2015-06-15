using UnityEngine;
using System.Collections;

public class rotatescript : MonoBehaviour {


	FPController fpc;

	// Use this for initialization
	void Start () {
		fpc = GetComponent<FPController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.E)) {
			fpc.Rotate(Quaternion.AngleAxis(5, Vector3.up));
		}
		if (Input.GetKey(KeyCode.Q)) {
			fpc.Rotate(Quaternion.AngleAxis(-5, Vector3.up));
		}
	}
}
