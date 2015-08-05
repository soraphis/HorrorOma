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
		Transform birne = this.transform.parent.FindChild("birne");
		Renderer rend = birne.GetComponent<Renderer> ();

		if(doesFlicker || forced){
			t -= Time.deltaTime;
			if(t < 0){
				if(this.mylight.enabled){
                    GetComponent<AudioSource>().Play();
					StartCoroutine(flickerOut());
					t = Random.Range(1.3f, 2.8f);
					rend.material.SetColor("_EmissionColor", Color.white*0.8f);
				}
				else{
					this.mylight.enabled = true;
					forced = false;
					t = Random.Range(4.3f, 6.8f);
					rend.material.SetColor("_EmissionColor", Color.white*0f);
				}
			}
		}

		if(this.mylight.enabled){
			rend.material.SetColor("_EmissionColor", Color.white*0.8f);
		}
		else{
			rend.material.SetColor("_EmissionColor", Color.white*0f);
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
		Transform birne = this.transform.parent.FindChild("birne");
		Renderer rend = birne.GetComponent<Renderer> ();


		this.mylight.enabled = false;
		rend.material.SetColor("_EmissionColor", Color.white*0f);
		for(int i = 0; i < Random.Range(8, 14); ++i){
			this.mylight.enabled = !this.mylight.enabled;

			if(this.mylight.enabled){
				rend.material.SetColor("_EmissionColor", Color.white*0.8f);
			}else{
				rend.material.SetColor("_EmissionColor", Color.white*0f);
			}
			yield return new WaitForSeconds(Random.Range(0.03f, 0.1f));
		}

		this.mylight.enabled = false;
		rend.material.SetColor("_EmissionColor", Color.white*0f);

	}
}
