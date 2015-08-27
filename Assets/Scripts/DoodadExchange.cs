using UnityEngine;
using System.Collections;

public class DoodadExchange : MonoBehaviour {

	[SerializeField] private GameObject GeruempelraumDoodadWrapper = null;
	[SerializeField] private GameObject DecalWrapper = null;


	// Use this for initialization
	void Start () {

	}

	public void AddDecalLayer(int layer){
		for(int i = 0; i < DecalWrapper.transform.childCount; ++i){
			Transform room = DecalWrapper.transform.GetChild(i);
			if(room == null) continue;

			Transform layerObj = room.Find(layer.ToString());
			if(layerObj != null) layerObj.gameObject.SetActive(true);

			layerObj = room.Find(string.Format("{0} off", layer));
			if(layerObj != null) layerObj.gameObject.SetActive(false);
		}
	}

	public void Exchange(int newStateNumber){
		GeruempelraumDoodadWrapper.transform.Find (((int)(newStateNumber - 1)).ToString()).gameObject.SetActive (false);
		GeruempelraumDoodadWrapper.transform.Find (newStateNumber.ToString()).gameObject.SetActive (true);
	}

}
