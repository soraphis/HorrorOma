﻿using UnityEngine;
using System.Collections;

public class FinalTriggerZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			if(StateMachine.Instance.State == GameState.SearchExit05){
				Application.LoadLevel("Credits");
			}else{
				Debug.Log ("Cheater");
			}
		}
	}
}