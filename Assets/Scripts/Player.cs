//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour {

	public static Player instance {
		get;
		private set;
	}

	public delegate void LevelLoadComplete();
    public event LevelLoadComplete onLevelLoad;
	public GameObject LampLight;

	[HideInInspector]
	public Pickable inhand = null;

	public Pickable BOX;
	public Pickable LAMP;

	private IEnumerator Load(){
        AsyncOperation levelLoader = Application.LoadLevelAdditiveAsync("UIScene");
		yield return levelLoader;
        if(onLevelLoad != null) onLevelLoad();
    }

	protected Player (){

	}


    void Awake(){
        Player.instance = this;
    }

   	void Start(){

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(Load());

		if (BOX.worldObject.activeSelf) {
			BOX.handsObject.SetActive(false);
		}

		if (LAMP.worldObject.activeSelf) {
			LAMP.handsObject.SetActive(false);
		}
	}

	void Update(){
		if (LAMP.worldObject.activeSelf) {
			LampLight.SetActive (false);
		} else {
			LampLight.SetActive(true);
		}
	}
}


