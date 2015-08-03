using UnityEngine;
using System.Collections;


public class PlayerActionSensor : MonoBehaviour {

	public float PlayerActionRange = 2.0f;

	public GameObject Selected {
		private set; get;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		////////////////////// build raycast
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2, 0));

		GameObject newselect = null;
		if (Physics.Raycast (ray, out hit)) {
			if(hit.distance < PlayerActionRange){
				TriggerObject(hit.collider, out newselect);
			}
		}

		if (this.Selected != newselect) {
			Highlighter h;
			if(this.Selected != null){
				h = this.Selected.GetComponent<Highlighter> ();
				if(h != null) h.highlighted = false;
			}

			if(newselect != null){
				h = newselect.GetComponent<Highlighter> ();
				if(h != null) h.highlighted = true;
			}
		}

		this.Selected = newselect;



		if (Input.GetButtonDown ("Fire1")) {

			if(Player.instance.inhand != null
			   && Player.instance.inhand.worldObject != null
			   && Player.instance.inhand.handsObject != null){
				// Debug.Log (Player.instance.inhand);

				// drop that shit
				Player.instance.inhand.PickDrop();
				Player.instance.inhand = null;
				return;
			}
			if (Selected == null)
				return;

		    foreach (var c in Selected.GetComponents(typeof(IViewOver)))
		    {
		        ((IViewOver)c).fireAction();
		    }
		}
	}


	void TriggerObject(Collider other, out GameObject newselect){
		newselect = null;
		if (other.gameObject.layer == 8) // world
			return;

		newselect = other.gameObject;
	}

}
