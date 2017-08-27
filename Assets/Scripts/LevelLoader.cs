using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	public static LevelLoader instance;

	private AsyncOperation async = null;

	[SerializeField] GameObject ProgressCircle;
	private Image image;

	public bool ConditionToLoad = false;

	public static void LoadLevel(int index){ instance.StartCoroutine(instance.Load (index)); }
	public static void LoadLevel(string name){ instance.StartCoroutine(instance.Load (name)); }

	private IEnumerator Load(int index){
        yield return new WaitForSeconds(1);
        async = SceneManager.LoadSceneAsync(index);
        async.allowSceneActivation = false;
        image.fillAmount = 0;
        while (!async.isDone) {
            image.fillAmount = async.progress / 0.91f;
            if (Input.GetKeyDown(KeyCode.Escape) || ConditionToLoad){
                ConditionToLoad = true;
                async.allowSceneActivation = true;
            }
            yield return null;
        }
        image.fillAmount = 1;
        Debug.Log("level loaded complete");
        yield return new WaitForSeconds(0.8f);
    }

	private IEnumerator Load(string lvlname){    // todo: cleanup this copy&paste
        yield return new WaitForSeconds(1);
        async = SceneManager.LoadSceneAsync(lvlname);
        async.allowSceneActivation = false;
        async.priority = 10;
        image.fillAmount = 0;
        while (!async.isDone) {
            image.fillAmount = async.progress / 0.9f;
            Debug.Log(image.fillAmount);

            yield return null;
	    }
        image.fillAmount = 1;
        Debug.Log("level loaded complete");
        yield return null;
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

    }

}
