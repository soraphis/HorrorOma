﻿using UnityEngine;
using System.Collections;

public class WrongBoxScript : MonoBehaviour, IViewOver {

	[SerializeField] private string errorMessage;

	#region IViewOver implementation

	    public void fireSelect ()
	    {
	    }

	    public void fireAction ()
	    {
			NotificationText.SimpleScreenText(errorMessage);
	    }

	#endregion

    public void ChangeMessage(string msg) {
        errorMessage = msg;
    }

	void Start(){
		if(GetComponent<Highlighter>() == null){
			gameObject.AddComponent<Highlighter>();
		}
	}


}
