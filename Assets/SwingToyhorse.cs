using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SwingToyhorse : MonoBehaviour {

	private float swingTime = 2.0f; // 2 * pi * sqrt( 1m / 9.81m/s^2) = ~ 2s
	private const float maximumDeflection = 30f;
	private const float deflectionReduction = 3f;
	private float currentDeflection = 0f;
	private float timer = 0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		currentDeflection = Mathf.Max(0, currentDeflection-deflectionReduction*Time.deltaTime);
		if(currentDeflection <= 0f) return;
		timer += Time.deltaTime;
		Vector3 rot = transform.localEulerAngles;
		rot.x = currentDeflection * Mathf.Cos(Mathf.PI * timer/swingTime);
		transform.localEulerAngles = rot;


	}

	public void deflect(int amount){
		float alpha = ((transform.localEulerAngles.x + 180) % 360) - 180;
		currentDeflection = Mathf.Clamp (currentDeflection + amount, 0, maximumDeflection);
		timer = Mathf.Acos (alpha / currentDeflection) * swingTime / Mathf.PI;
	}

	private IEnumerator smoothDeflect(int amount){
		for(int i = 0; i < 30; ++i){
			currentDeflection = Mathf.Clamp(currentDeflection + amount*1/30f, 0, maximumDeflection);
			yield return new WaitForSeconds(1/30f);
		}
	}

}
