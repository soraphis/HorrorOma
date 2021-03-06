﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class LightFlicker : MonoBehaviour {

	Light mylight;
	float t;
	public bool doesFlicker = false;
	private bool forced = false;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		mylight = this.GetComponent<Light>();
        audioSource = this.GetComponentInChildren<AudioSource>();
        t = Random.value * 10;
	}
	
	// Update is called once per frame
	void Update () {
		Transform birne = this.transform.parent.FindChild("birne");
		Renderer rend = birne.GetComponent<Renderer> ();

		if(doesFlicker || forced){
			t -= Time.deltaTime;
			if(t < 0){
				if(this.mylight.enabled){
                    audioSource.Play();
					StartCoroutine(flickerOut());
					t = Random.Range(1.3f, 2.8f);
					//rend.material.SetColor("_EmissionColor", Color.white*0.8f);
				}
				else{
					this.mylight.enabled = true;
					forced = false;
					t = Random.Range(4.3f, 6.8f);
					//rend.material.SetColor("_EmissionColor", Color.white*0f);
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
		forced = true;
		t = seconds;
        audioSource.Play();
        StartCoroutine(flickerOut());
	}

	private IEnumerator flickerOut(){
		Transform birne = this.transform.parent.FindChild("birne");
		Renderer rend = birne.GetComponent<Renderer> ();


		this.mylight.enabled = true;
		//rend.material.SetColor("_EmissionColor", Color.white*0f);
		for(int i = 0; i < Random.Range(8, 12); ++i){
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
