using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityStandardAssets.ImageEffects;

public class HighlightObjects : MonoBehaviour {

    private RenderTexture hightlightRT;
    private RenderTargetIdentifier rtID;
    private CommandBuffer buffer;

    public Material DrawMaterial;
    public Material HighlightMaterial;
    private List<GameObject> highlightList = new List<GameObject>();
    private BlurOptimized blur;
    private Antialiasing antialiasing;

    private void CreateBuffers() {
        hightlightRT = new RenderTexture(Screen.width, Screen.height, 0);
        rtID = new RenderTargetIdentifier(hightlightRT);
        buffer = new CommandBuffer();

        blur = new BlurOptimized();
        blur.blurShader = Shader.Find("Hidden/FastBlur");
        blur.blurSize = 0.8f;
        blur.blurIterations = 2;
        blur.downsample = 2;
        blur.blurType = BlurOptimized.BlurType.StandardGauss;

        antialiasing = new Antialiasing();
        antialiasing.shaderFXAAPreset2 = Shader.Find("Hidden/FXAA Preset 2");
        antialiasing.shaderFXAAPreset3 = Shader.Find("Hidden/FXAA Preset 3");
        antialiasing.shaderFXAAII = Shader.Find("Hidden/FXAA II");
        antialiasing.shaderFXAAIII = Shader.Find("Hidden/FXAA III (Console)");
        antialiasing.dlaaShader = Shader.Find("Hidden/DLAA");
        antialiasing.ssaaShader = Shader.Find("Hidden/SSAA");
        antialiasing.nfaaShader = Shader.Find("Hidden/NFAA");
        antialiasing.mode = AAMode.FXAA1PresetA;
    }

    public void addToHighlight(GameObject obj) {
        if(! highlightList.Contains(obj))
            highlightList.Add(obj);
    }
    public void removeToHighlight(GameObject obj) { highlightList.Remove(obj); }

    private void RenderHighlights() {
        buffer.SetRenderTarget(rtID);

        foreach(var o in highlightList) {
            Renderer renderer = o.GetComponent<Renderer>();
            buffer.DrawRenderer(renderer, DrawMaterial, 0);
        }

        RenderTexture.active = hightlightRT;
        Graphics.ExecuteCommandBuffer(buffer);
        RenderTexture.active = null;
    }

	// Use this for initialization
	void Start () {
	    CreateBuffers();
	}

    void Update() {
       /* highlightList.Clear();
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.1f, transform.forward, out hit, 3)) {
            var ic = hit.collider.gameObject.GetComponent<Interactable>();
            if (ic != null) addToHighlight(ic.gameObject);
        }*/
        
    }

    private void ClearCommandBuffers() {
        buffer.Clear();

        RenderTexture.active = hightlightRT;
        GL.Clear(true, true, Color.clear);
        RenderTexture.active = null;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination) {
        ClearCommandBuffers();

        RenderHighlights();

        RenderTexture rt1 = RenderTexture.GetTemporary(Screen.width, Screen.height, 0);
        blur.OnRenderImage(hightlightRT, rt1);

        //antialiasing.OnRenderImage(rt1, rt1);

        HighlightMaterial.SetTexture("_OccludeMap", hightlightRT);
        Graphics.Blit(rt1, rt1, HighlightMaterial, 0);

        HighlightMaterial.SetTexture("_OccludeMap", rt1);
        Graphics.Blit(source, destination, HighlightMaterial, 1);

        RenderTexture.ReleaseTemporary(rt1);
    }

}
