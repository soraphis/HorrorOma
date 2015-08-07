using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class WaterColliderHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){ // player entered water
            if(WaterSystem.instance.WaterElectrified)
                other.GetComponent<GameOver>().Kill(GameOver.DeathType.ELECTRIFICATION);
        	else{
                FPController fp = other.GetComponent<FPController>();
                fp.WaterSteps = true;
            }
        }
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){ // player entered water
            FPController fp = other.GetComponent<FPController>();
            fp.WaterSteps = false;
        }
    }
}
