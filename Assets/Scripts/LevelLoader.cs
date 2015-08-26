using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	static LevelLoader instance;

	private AsyncOperation async = null;

	[SerializeField] GameObject ProgressCircle;
	private Image image;

	public bool ConditionToLoad = true;

	public static void LoadLevel(int index){ instance.StartCoroutine(instance.Load (index)); }
	public static void LoadLevel(string name){ instance.StartCoroutine(instance.Load (name)); }

	private IEnumerator Load(int index)
	{
		async = Application.LoadLevelAsync(index);
		async.allowSceneActivation = false;
		yield return async;
		Debug.Log ("level loaded complete");
	}

	private IEnumerator Load(string name)
	{
		async = Application.LoadLevelAsync(name);
		async.allowSceneActivation = false;
		yield return async;
	}

	void Awake(){
		if (LevelLoader.instance != null) {
			Destroy (this);
			return;
		}
		LevelLoader.instance = this;
	}

	// Use this for initialization
	void Start () {
		image = ProgressCircle.GetComponent<Image> ();
		LevelLoader.LoadLevel (1);
	}

	// Update is called once per frame
	void Update () {
		if (instance.async == null)
			return;
		image.fillAmount = instance.async.progress/0.9f;
		if(ConditionToLoad){ async.allowSceneActivation = true; }

	}

}
