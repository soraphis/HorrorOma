using UnityEngine;
using System.Collections;

public class AmbientSound : MonoBehaviour {
	//public AudioSource mainLoop;
	[SerializeField] private AudioClip [] ambientSounds;
	[SerializeField] private AudioSource ambientSource;

	private const float time = 10f;
	private float timer = time;

	// Update is called once per frame
	void Update () {
	 	timer -= Time.deltaTime;
		if(timer > 0) return;
		timer = time;
		if(ambientSource.isPlaying) return;
		if(Random.value < 0.8) return;
		ambientSource.clip = ambientSounds[(int)((Random.value * 100) % ambientSounds.Length)];
		ambientSource.Play();
	}

}
