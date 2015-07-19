using UnityEngine;
using System.Collections;

public class DoorOpen : MonoBehaviour, IViewOver {

	#region IViewOver implementation
	public void fireSelect ()
	{

	}
	public void fireAction ()
	{
		open = !open;
	}
	#endregion

	private bool open = false;
	private float smooth = 1.0f;
	public static float doorspeed = 0.1f;

	private Quaternion startRotation;
	private Transform parent;
	void Start () {
		this.parent = this.transform.parent;
		startRotation = parent.transform.rotation * Quaternion.identity;
	}
	

	void Update () {
		Quaternion doorNew;
		if (open) {
			doorNew = startRotation * Quaternion.Euler (0, 0, 80);

		} else {
			doorNew = startRotation;
		}
		float angle = Quaternion.Angle (parent.transform.rotation, doorNew);
		parent.transform.rotation = Quaternion.Lerp (parent.transform.rotation, doorNew, Time.deltaTime * smooth);
		
		if (angle <= smooth)
			parent.transform.rotation = doorNew;
	}


}
