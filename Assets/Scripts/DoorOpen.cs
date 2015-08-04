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
                return;
			}
		}
		sleep = false;
		time = 0.0f;
		open = !open;
		startRotation = parent.transform.rotation;
	}
	#endregion

	private bool open = false;
	private bool closed = true; // for simple sound controll

	private float smooth = 1f;
	private static float OPENTIME = 1.4f; // seconds
	private float time = 0.0f;

	public static float doorspeed = 0.1f;

	public bool locked = false;


	private AudioSource audioSource;
	public AudioClip dooropen;
	public AudioClip doorclose;
	public AudioClip doorlocked;

	private bool sleep = true;
	private Quaternion startRotation;
	private Quaternion closedRotation;
	private Quaternion openedRotation;

	private Transform parent;
	void Start () {
		this.parent = this.transform.parent.parent;
		startRotation = parent.transform.rotation * Quaternion.identity;
		openedRotation = startRotation * Quaternion.Euler (0, 80, 0);
		closedRotation = startRotation * Quaternion.identity;

		audioSource = this.GetComponent<AudioSource> ();
	}

	void Update () {
		if(sleep) return;
		Quaternion doorNew = open ? openedRotation
			: closedRotation;

		float angle = Quaternion.Angle (startRotation, doorNew);
		if (open && closed) {
			if(dooropen != null && ! audioSource.isPlaying){
				audioSource.PlayOneShot(dooropen);
			}
			closed = false;
		}
		time += Time.deltaTime * smooth;
		float f = time/(OPENTIME - OPENTIME * (1.001f - angle/80f));
		parent.transform.rotation = Quaternion.Slerp (startRotation, doorNew, f);
		if(f >= 0.9){
			if(!open & !closed){
			closed = true;
			if(doorclose != null && ! audioSource.isPlaying){
				audioSource.PlayOneShot(doorclose);
			}
			}
		}
		if(f >= 0.99){
		//if (angle <= smooth) {
			parent.transform.rotation = doorNew;
			startRotation = parent.transform.rotation;
			sleep = true;
			time = 0.0f;
		}
	}


}
