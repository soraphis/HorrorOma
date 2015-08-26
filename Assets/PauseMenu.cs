using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	[SerializeField] private bool justButtonFunctions = false;
	private bool isPause = false;
	private FPController fpsc;

	// Use this for initialization
	void Start () {
		GameObject acteuer = GameObject.Find ("Akteuer");
		if (acteuer == null) {
			justButtonFunctions = true;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			return;
		}
		fpsc = acteuer.GetComponent<FPController> ();
		Process ();
	}
	
	// Update is called once per frame
	void Update () {
		if (justButtonFunctions)
			return;
		if (! Input.GetButtonDown ("Cancel"))
			return;
		Toggle ();
	}

	private void Process(){
		transform.GetChild (0).gameObject.SetActive(isPause);
		
		Time.timeScale = isPause ? 0 : 1;
		fpsc.enabled = !isPause;
		Cursor.lockState = isPause ? CursorLockMode.None : CursorLockMode.Locked;
		Cursor.visible = isPause;
	}

	public void Toggle(){
		isPause = !isPause;
		Process ();
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void Restart(){
		Application.LoadLevel (0);
	}
}
