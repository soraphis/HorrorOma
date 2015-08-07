using UnityEngine;
using System.Collections;

public class EventHandler : MonoBehaviour{

    public delegate void handler();
    public event handler OnDestroyCallback;

    void OnDestroy(){
        if (OnDestroyCallback != null) OnDestroyCallback();
    }

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
