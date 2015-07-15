using UnityEngine;
using System.Collections;


public class boxPick : MonoBehaviour {
	public GameObject kiste;
	public GameObject kisteOnGround;
	bool isPick = false;
	// Use this for initialization
	void Start () {
		kiste.SetActive (false);
		kisteOnGround.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			if (isPick) {
				kiste.SetActive (false);
				kisteOnGround.SetActive (true);
				kisteOnGround.transform.position = this.transform.position+this.transform.forward;
				isPick = false;
			} else {
				RaycastHit hit = new RaycastHit (); 
				Vector3 fwd = transform.forward;
				Debug.DrawRay (transform.position, fwd);
				if (Physics.Raycast (new Ray (this.transform.position, fwd), out hit, 2.0f) && hit.collider.CompareTag ("Kiste")) {
					Debug.Log ("pickBox");
					pick ();
				}
			}
		}
	}

	void pick(){
		if (isPick == false) {
			//falls die Box nicht kindobjekt von Fp-Controller benötigt
			//kiste.transform.position = this.transform.position+this.transform.forward;
			kiste.SetActive (true);
			kisteOnGround.SetActive (false);
			isPick = true;
		} 
	}
}
