using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;

public class Fuse : MonoBehaviour {

    private Color offColor = new Color(100,0,0);
    private Color onColor = new Color(0, 100, 0);
    private bool _powered = false;
	public bool PowerAble = true;
    public bool IsOnAtStart;

	public bool powered {
		get {
			return _powered;
		}
		set {
			_powered = value;
			RefreshItems();
		}
	}

    private void UpdateLighswitchesLight()
    {
        foreach (Transform child in transform)
        {
            var lightTransform = child.Find("light");
            if (lightTransform != null)
            {
                if (powered)
                {
                    var mats = lightTransform.GetComponent<Renderer>().materials;
                    mats[0].SetColor("_Color", onColor);
                    mats[0].SetColor("_EmissionColor", onColor);
                }
                else
                {
                    var mat = lightTransform.GetComponent<MeshRenderer>().material;
                    mat.SetColor("_Color", offColor);
                    mat.SetColor("_EmissionColor", offColor);
                }
            }
        }
    }

	public GameObject[] Lights = null;


	public void RefreshItems()
	{
        foreach (var myGameObject in Lights)
		{
			// each lightsorce (pointlight, spotlight, ...)
			foreach (var myLight in myGameObject.GetComponentsInChildren<Light>(true))
			{
				myLight.enabled = _powered & PowerAble;

			}
			foreach(LightFlicker flicker in myGameObject.GetComponentsInChildren<LightFlicker>(true)){
				flicker.enabled = _powered & PowerAble;
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

        UpdateLighswitchesLight();
    }

	void Start()
	{
	    if (IsOnAtStart)
	    {
	        _powered = true;
            UpdateLighswitchesLight();
	    }
	    else
	    {
	        RefreshItems();
	    }
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
