using UnityEngine;
using System.Collections;

public class MirrorCam : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 v = Camera.main.transform.position - transform.parent.position;
		Vector3 r = 2 * Vector3.Dot(v, transform.parent.up)*transform.parent.up - v;
		this.transform.LookAt(transform.parent.position + r);
	}
}

