using UnityEngine;
using System.Collections;

public class ElectricalSparksController : MonoBehaviour {

    const float StartTimer = 0.1f;
    float timer = 0;

    GameObject [] childs;

	// Use this for initialization
	void Start () {
        var lightnings = GetComponentsInChildren<LightningBolt>();
        childs = new GameObject[lightnings.Length];
        for(int i = 0; i < lightnings.Length; ++i){
            childs[i] = lightnings[i].gameObject;
        }

	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
        if(timer > 0)return;
		foreach(GameObject child in childs){
            if(Random.value > 0.4f)
            	child.gameObject.SetActive(false);
            else
                child.gameObject.SetActive(true);
        }
		timer = StartTimer;
	}
}
