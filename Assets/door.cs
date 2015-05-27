using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animator.SetBool("open", true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
