using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

	Light mylight;
	float t;
	public bool doesFlicker = false;
	private bool forced = false;

	// Use this for initialization
	void Start () {
		mylight = this.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {

		if(doesFlicker || forced){
			t -= Time.deltaTime;
			if(t < 0){
				if(this.mylight.enabled){
					StartCoroutine(flickerOut());
					t = Random.Range(1.3f, 2.8f);
				}
				else{
					this.mylight.enabled = true;
					forced = false;
					t = Random.Range(4.3f, 6.8f);
				}


			}
		}
	}

	public void ForceFlicker(){	this.ForceFlicker(1); }

	// turns the light off
	public void ForceFlicker(float seconds){
		flickerOut();
		forced = true;
		t = seconds;
	}

	private IEnumerator flickerOut(){
		this.mylight.enabled = false;
		for(int i = 0; i < Random.Range(5, 8); ++i){
			this.mylight.enabled = !this.mylight.enabled;
			yield return new WaitForSeconds(Random.Range(0.01f, 0.1f));
		}

		this.mylight.enabled = false;
	}
}
