using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISelector : MonoBehaviour {

    private void Fade(float f){
        Color c = image.color;
        Vector3 s = transform.localScale;
        c.a = f;
        s.x = 1+(1-f);
        s.y = 1+(1-f);
		image.color = c;
		transform.localScale = s;
    }

    private IEnumerator FadeOut(){
		for(float f = 1f; f >= 0; f -= 0.1f){
            Fade(f);
            yield return null;
        }
        Fade(0f);
    }

    private IEnumerator FadeIn(){
		for(float f = 0f; f <= 1; f += 0.1f){
            Fade(f);
            yield return null;
        }
        Fade(1f);
    }

    private bool visible = true;

    public bool Visible{
        get{ return visible; }
        set{
            if(value != visible){
                if(value){StartCoroutine("FadeIn");}
                else{ StartCoroutine("FadeOut"); }
            }
            visible = value;
        }
    }

	Image image;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();

		Visible = false; // Visible setter function!
	}
	
	// Update is called once per frame
	void Update () {

	}
}
