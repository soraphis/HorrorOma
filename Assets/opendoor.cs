using UnityEngine;
using System.Collections;

public class opendoor : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			RaycastHit hit = new RaycastHit(); 
			Vector3 fwd = transform.forward;
			Debug.DrawRay(transform.position, fwd);
			if( Physics.Raycast(new Ray(this.transform.position, fwd), out hit, 2.5f) && hit.collider.CompareTag("Door") ){
				Transform door = hit.collider.transform;
				Animator anim = door.GetComponent<Animator>();
				anim.SetTrigger("triggerdoor");
			}
		}
	}
}
