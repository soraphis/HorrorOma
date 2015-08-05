using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class Fuse : MonoBehaviour {


	private bool _powered = false;
	public bool PowerAble = true;

	public bool powered {
		get {
			return _powered;
		}
		set {
			_powered = value & PowerAble;
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
			foreach(LightFlicker flicker in myGameObject.GetComponentsInChildren<LightFlicker>(true)){
				flicker.enabled = _powered;
			}

			Transform birne = myGameObject.transform.FindChild("birne");
			if(birne == null) continue;
			Renderer rend = birne.GetComponent<Renderer>();

			if(_powered){
				//DynamicGI.SetEmissive(rend, Color.red * 0.8f);
				rend.material.SetColor("_EmissionColor", Color.white*0.8f);
				//
			}else{
				//DynamicGI.SetEmissive(rend, Color.green * 0f);
				rend.material.SetColor("_EmissionColor", Color.white*0f);
			}
			DynamicGI.UpdateMaterials(rend);
		}
	}

	void Start(){

		toggleItems ();
	}


#if UNITY_EDITOR
	void OnDrawGizmosSelected(){
		Gizmos.color = Color.cyan;
		foreach (var l in Lights) {
			if(l != null){
				Gizmos.DrawLine (this.transform.position, l.transform.position);               
			}
		}
	}
#endif

}
