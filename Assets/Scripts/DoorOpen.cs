using UnityEngine;
using System.Collections;

/*
 * Place this at the door
 */
public class DoorOpen : MonoBehaviour{

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

    public bool Open{
        get{ return open; }
        private set{ open = value; if(open) locked = false; }
    }

    public void Trigger(){
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

    // triggers if door is not @param open
    public void ConditionalTrigger(bool open){
        if(this.open != open) Trigger();
    }

	void Start () {

		this.parent = this.transform.parent.parent;
		startRotation = parent.transform.rotation * Quaternion.identity;
		openedRotation = startRotation * Quaternion.Euler (0, 80, 0);
		closedRotation = startRotation * Quaternion.identity;

		audioSource = this.GetComponent<AudioSource> ();
	}

	/**
	 * Closes/Openes door without animation
	 */
    public void ForceSet(bool open){
        Open = open;
        Quaternion doorNew = this.open ? openedRotation
        	: closedRotation;
        parent.transform.rotation = doorNew;
        startRotation = parent.transform.rotation;
        sleep = true;
        time = 0.0f;
    }

    // helper function for unityevents
    public void Lock(bool doorlocked){
		this.locked = doorlocked;
    }

	void Update () {
		if(sleep) return;
		Quaternion doorNew = Open ? openedRotation
			: closedRotation;

		float angle = Quaternion.Angle (startRotation, doorNew);
		if (Open && closed) {
			if(dooropen != null && ! audioSource.isPlaying){
				audioSource.PlayOneShot(dooropen);
			}
			closed = false;
		}
		time += Time.deltaTime * smooth;
		float f = time/(OPENTIME - OPENTIME * (1.001f - angle/80f));
		parent.transform.rotation = Quaternion.Slerp (startRotation, doorNew, f);
		if(f >= 0.9){
			if(!Open & !closed){
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
