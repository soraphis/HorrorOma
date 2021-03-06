﻿using UnityEngine;
using System.Collections;

public class MakePictureCreepy : MonoBehaviour {

	[SerializeField] private bool creepy = false;
	[SerializeField] private float time = 2f;
	private Renderer myRenderer;
	private bool pause = false;

	// [ExecuteInEditMode]
	// Use this for initialization
	void Start () {
		Transform creepyPic = transform.Find ("PictureCreepy");
		this.myRenderer = creepyPic.GetComponent<Renderer> ();
	}

	// Update is called once per frame
	void Update () {
		float transparency = creepy ? 1 : 0;
		Color c = myRenderer.material.color;

		if (Mathf.Abs (c.a - transparency) > 0.01f) {
			//NotificationText.SimpleScreenText(c.a.ToString(), 0.1f);
			c.a += (transparency - (1 - transparency)) * Time.deltaTime / time;
			c.a = Mathf.Clamp01 (c.a);
			myRenderer.material.color = c;
		} else {
			pause = true;
		}

	}

	private IEnumerator toggle(){
		while (!pause) {
			yield return new WaitForSeconds(0.2f);
		}
		creepy = !creepy;
		pause = false;
	}

	public void ToggleCreepy(){
		if (! this.gameObject.activeInHierarchy)
			return;
		StartCoroutine (toggle ());
	}


}
