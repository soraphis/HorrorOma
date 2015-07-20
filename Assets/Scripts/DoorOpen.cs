using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour, IViewOver {

	#region IViewOver implementation
	public void fireSelect ()
	{

	}
	public void fireAction ()
	{
		if (!open && locked) {
			if(doorlocked != null && ! audioSource.isPlaying){
				audioSource.PlayOneShot(doorlocked);
			}
		}
		open = !open;
	}
	#endregion

	private bool open = false;
	private bool closed = true; // for simple sound controll

	private float smooth = 1.0f;
	public static float doorspeed = 0.1f;

	public bool locked = false;


	private AudioSource audioSource;
	public AudioClip dooropen;
	public AudioClip doorclose;
	public AudioClip doorlocked;


	private Quaternion startRotation;
	private Transform parent;
	void Start () {
		this.parent = this.transform.parent;
		startRotation = parent.transform.rotation * Quaternion.identity;
		audioSource = this.GetComponent<AudioSource> ();
	}

	void Update () {
		Quaternion doorNew = open ? startRotation * Quaternion.Euler (0, 0, 80)
								: startRotation;

		float angle = Quaternion.Angle (parent.transform.rotation, doorNew);
		if (open && closed) {
			if(dooropen != null && ! audioSource.isPlaying){
				audioSource.PlayOneShot(dooropen);
			}
			closed = false;
		}

		parent.transform.rotation = Quaternion.Lerp (parent.transform.rotation, doorNew, Time.deltaTime * smooth);
		
		if (angle <= smooth) {
			parent.transform.rotation = doorNew;
			if(!open & !closed){
				closed = true;
				if(doorclose != null && ! audioSource.isPlaying){
					audioSource.PlayOneShot(doorclose);
				}
			}
		}
	}


}
