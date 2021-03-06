using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	[SerializeField] private GameObject boxSpots;

	private IEnumerator Load(){
        // AsyncOperation levelLoader = Application.LoadLevelAdditiveAsync("UIScene");
        AsyncOperation levelLoader = SceneManager.LoadSceneAsync("UIScene", LoadSceneMode.Additive);
		yield return levelLoader;
        if(onLevelLoad != null) onLevelLoad();
    }

	protected Player (){

	}


    void Awake(){
        Player.instance = this;
		StateMachine.Reset();
		onLevelLoad += () => {
			NotificationText.Initialize();
		};
    }

   	void Start(){
		StartCoroutine(Load());

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

		this.Actor = GameObject.FindGameObjectWithTag("Player");

		if (BOX.worldObject.activeSelf) {
			Transform t = boxSpots.transform.GetChild((int)((Random.value * 100)%boxSpots.transform.childCount));

			BOX.worldObject.transform.position = t.position;

			BOX.handsObject.SetActive(false);
		}

		if (LAMP.worldObject.activeSelf) {
			LAMP.handsObject.SetActive(false);
		}

        Camera.main.clearStencilAfterLightingPass = true;
    }

	void Update(){
		if (LAMP.worldObject.activeSelf) {
			LampLight.SetActive (false);
		} else {
			LampLight.SetActive(true);
		}
	}
}
