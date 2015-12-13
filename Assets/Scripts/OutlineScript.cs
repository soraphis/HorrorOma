using UnityEngine;
using System.Collections;

/*
public class OutlineScript : MonoBehaviour {
	public GameObject player;
	public Shader shader1;
    public Shader shader2;
	public float outlineSize = 0.3f;
	public float distanceToAct = 2;
	public Color outlineColor = Color.red;
	private bool alreadyNear = false;
	
	// Use this for initialization
	void Start () {
	shader1 = Shader.Find("Standard");
    shader2 = Shader.Find("Standard Outlined");
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
		if (distance <= distanceToAct) {
			if (!alreadyNear) {
				alreadyNear = true;
				GetComponent<Renderer>().material.shader = shader2;
				GetComponent<Renderer>().material.SetFloat("_Outline", outlineSize);
				GetComponent<Renderer>().material.SetColor("_OutlineColor", outlineColor);
			}
		} else {
			alreadyNear = false;
			GetComponent<Renderer>().material.shader = shader1;
		}
	}
}
*/
