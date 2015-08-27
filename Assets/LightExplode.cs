using UnityEngine;
using System.Collections;

public class LightExplode : MonoBehaviour {

	private Light myLight;
	[SerializeField] private AudioClip breakbulb;

	// Use this for initialization
	void Start () {
		myLight = transform.Find("Point light").GetComponent<Light>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void Explode(){
		StartCoroutine(ExplodeRoutine());
	}

	private IEnumerator ExplodeRoutine(){
		for(int i = 0; i < 10; ++i){
			myLight.intensity += 1f;
			yield return null;
		}
		yield return new WaitForSeconds(0.1f);
		AudioSource.PlayClipAtPoint(breakbulb, transform.position);
		Destroy(this.gameObject);
	}
}
