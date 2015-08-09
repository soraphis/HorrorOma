using UnityEngine;
using System.Collections;

public class WaterPipeLeak : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<ParticleEmitter>().enabled = WaterSystem.instance.WaterActivated;
        this.GetComponent<ParticleRenderer>().enabled = WaterSystem.instance.WaterActivated;
    }
}
