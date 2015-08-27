using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroScript : MonoBehaviour {

	[SerializeField] private float delay = 5f;
	[SerializeField] private float fadeTime = 0.6f;
	[SerializeField] private bool secretFlag = false;

	private Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
		StartCoroutine(FadeIn());
	}

	private IEnumerator FadeIn(){
		yield return new WaitForSeconds(delay);
		for(float f = 0f; f <= 1; f += 0.05f){
            Fade(f);
            yield return new WaitForSeconds(0.05f/fadeTime);
        }
        Fade(1f);
		if(secretFlag){
			yield return new WaitForSeconds(1f);
			LevelLoader.instance.ConditionToLoad = true;
		}
    }

	private void Fade(float f){
        Color c = image.color;
        c.a = f;
		image.color = c;
    }
}
