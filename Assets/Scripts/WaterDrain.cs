using UnityEngine;
using System.Collections;

public class WaterDrain : MonoBehaviour {


    void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == 4) // water
        	WaterSystem.instance.WaterOverDrain = true;
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.layer == 4) // water
            WaterSystem.instance.WaterOverDrain = false;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
