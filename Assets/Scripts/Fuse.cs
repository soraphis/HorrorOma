using UnityEngine;
using System.Collections;

public class Fuse : MonoBehaviour {


	private bool _powered = false;

	public bool powered {
		get {
			return _powered;
		}
		set {
			_powered = value;
			toggleItems();
		}
	}	


	public GameObject[] Lights = null;

	private void toggleItems(){
		foreach (var myGameObject in Lights)
		{
			// each lightsorce (pointlight, spotlight, ...)
			foreach (var myLight in myGameObject.GetComponentsInChildren<Light>(true))
			{
				myLight.enabled = _powered;
			}
		}
	}

	void Start(){

		toggleItems ();
	}

}
