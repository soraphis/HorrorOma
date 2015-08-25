using System;
using System.Collections;
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
	public GameObject Actor;

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
		StartCoroutine(Load());

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

		this.Actor = GameObject.FindGameObjectWithTag("Player");

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
