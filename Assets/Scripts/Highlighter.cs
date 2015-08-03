using UnityEngine;
using System.Collections;
using Assets.Scripts;


public class Highlighter : MonoBehaviour {

	private static Color orange = new Color(1, 0.66667f, 0);

	public Shader outlineShader;
	public Shader defaultShader;
	public float outlineSize = 0.0025f;
	public Color outlineColor = Highlighter.orange;
	public GameObject Player;

	private Renderer rend;

	public bool highlighted;

	// Use this for initialization
	void Start () {
		this.rend = this.GetComponent<Renderer> ();
		defaultShader = this.rend.material.shader;

	}
	
	// Update is called once per frame
	void Update () {


		if (highlighted) {
			this.rend.material.shader = outlineShader;
			this.rend.material.SetFloat ("_Outline", outlineSize);
			this.rend.material.SetColor ("_OutlineColor", outlineColor);
		} else {
			this.rend.material.shader = defaultShader;
		}

	}
	/*
	void OnPreRender(){
		GL.wireframe = highlighted;
	}

	void OnPostRender(){
		GL.wireframe = false;
	}*/
}
