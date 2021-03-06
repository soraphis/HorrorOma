﻿using System.Collections;
using UnityEngine;


public class PlayerActionSensor : MonoBehaviour {

	public float PlayerActionRange = 2.0f;
	private int layermask = ~(Physics.IgnoreRaycastLayer | 1 << 4 | 1 << 9);
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



		if (Physics.Raycast (ray, out hit, PlayerActionRange, layermask)) {
			//if(hit.distance < PlayerActionRange){
				//NotificationText.SimpleScreenText(hit.collider.name, 0.1f);
				TriggerObject(hit.collider, out newselect);
			//}
		}


		if (this.Selected != newselect) {
			Highlighter h;
			if(this.Selected != null){
				h = this.Selected.GetComponent<Highlighter> ();
				if(h != null) {
					h.HighlightToggle(false);
                    GameObject.FindGameObjectWithTag("UICanvas").GetComponentInChildren<UISelector>().Visible = false;
				}
			}

			if(newselect != null){
				h = newselect.GetComponent<Highlighter> ();
				if(h != null){
                    h.HighlightToggle(true);
                    GameObject.FindGameObjectWithTag("UICanvas").GetComponentInChildren<UISelector>().Visible = true;
                }
			}
		}

		this.Selected = newselect;


		if (Input.GetButtonDown ("Fire1")) {
			//Drop Kiste
			if(Player.instance.inhand != null
			   && Player.instance.inhand.worldObject != null
			   && Player.instance.inhand.handsObject != null){
				// Debug.Log (Player.instance.inhand);
                if(Player.instance.inhand == Player.instance.BOX){
                    // drop that shit
                    Player.instance.inhand.PickDrop();
                    Player.instance.inhand = null;
                    return;
                }else if(Player.instance.inhand == Player.instance.LAMP
                && (Selected == null || Selected.tag == "Kiste")){
                    Player.instance.inhand.PickDrop();
                    Player.instance.inhand = null;
                    return;
                }

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
		if (other.gameObject.layer == 8 // world
         || other.gameObject.layer == 9 // decals
        // || other.gameObject.layer == 4 // water
        // || other.gameObject.layer == 10 // doodads
		)
            return;

		newselect = other.gameObject;
	}

}
