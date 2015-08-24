using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class WaterColliderHandler : MonoBehaviour {

	private Transform playerfeet;

	// Use this for initialization
	void Start () {
		playerfeet = GameObject.FindWithTag("Player").transform.Find("feet");
	}

	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other){
		if(other.transform == playerfeet){ // player entered water
            if(WaterSystem.instance.WaterElectrified)
                other.GetComponent<GameOver>().Kill(GameOver.DeathType.ELECTRIFICATION);
        	else{
                FPController fp = GameObject.FindWithTag("Player").GetComponent<FPController>();
                fp.WaterSteps = true;
            }
        }
    }

    void OnTriggerExit(Collider other){
        if(other.transform == playerfeet){ // player entered water
            FPController fp = GameObject.FindWithTag("Player").GetComponent<FPController>();
            fp.WaterSteps = false;
        }
    }
}
