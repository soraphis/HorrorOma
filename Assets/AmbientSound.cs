using UnityEngine;
using System.Collections;

public class AmbientSound : MonoBehaviour {
	//public AudioSource mainLoop;
	public AudioSource track_1;
	public AudioSource track_2;
	public AudioSource track_3;

	private bool playAudio = false;
	private AudioClip[] clips;
	private int i;
	void Start(){

	}

	// Update is called once per frame
	void Update () {
	 	if (!playAudio) {
			i = Random.Range (1, 3);
			playSound();
		}
	}

	void playSound(){
	
		StartCoroutine ("waitForRandomSeconds");
	}

	IEnumerator waitForRandomSeconds(){
		yield return new WaitForSeconds(Random.Range(30,60));

		if (i == 1) {
			playAudio = true;
			track_1.Play ();
		}
		if (i == 2) {
			playAudio = true;
			track_2.Play ();
		}
		if (i == 3) {
			playAudio = true;
			track_3.Play ();
		} 

	}
}
