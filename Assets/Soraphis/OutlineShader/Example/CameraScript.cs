using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var cam = this.GetComponent<Camera>();
        cam.clearStencilAfterLightingPass = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
