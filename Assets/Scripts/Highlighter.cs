using UnityEngine;
using System.Collections;
using Assets.Scripts;
using UnityEngine.Rendering;


public class Highlighter : MonoBehaviour {

	private static Color orange = new Color(1, 0.66667f, 0);

    private Shader outlineShader;
    private Shader defaultShader;
	private float outlineSize = 0.03f;
	private Color outlineColor = Highlighter.orange;
	public GameObject Player;

	private Renderer rend;

	public bool highlighted { private set; get; }
    private CommandBuffer buffer = null;

    // Use this for initialization
    void Start () {
		this.rend = this.GetComponent<Renderer> ();
		defaultShader = this.rend.material.shader;

		outlineShader = Shader.Find("Standard Outlined");
        defaultShader = Shader.Find("Standard");
    }

	// Update is called once per frame
	void Update () {
        /*if (highlighted) {
            Camera.main.GetComponent<HighlightObjects>().addToHighlight(this.gameObject);
        } else {
            Camera.main.GetComponent<HighlightObjects>().removeToHighlight(this.gameObject);
            //this.rend.material.shader = defaultShader;
        }*/
    }

    public void HighlightToggle(bool b) {
        highlighted = b;
        if (highlighted) {
            print("highlight!");
            Camera.main.GetComponent<HighlightObjects>().addToHighlight(this.gameObject);
        } else {
            Camera.main.GetComponent<HighlightObjects>().removeToHighlight(this.gameObject);
        }
        // if (buffer != null) Camera.main.RemoveCommandBuffer(CameraEvent.AfterFinalPass, buffer);
        /*
                if (highlighted) {
                    this.rend.material.shader = outlineShader;
                    this.rend.material.SetFloat("_Outline", outlineSize);
                    this.rend.material.SetColor("_OutlineColor", outlineColor);
                    buffer = new CommandBuffer();
                    buffer.DrawRenderer(rend, rend.material, 0, 5);

                    Camera.main.AddCommandBuffer(CameraEvent.AfterFinalPass, buffer);
                } else {
                    this.rend.material.shader = defaultShader;
                }
        */
    }

    public void HighlightToggle() {
        HighlightToggle(!highlighted);
    }

}
