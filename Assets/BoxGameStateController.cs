﻿using System.Collections;
using UnityEngine;

public class BoxGameStateController : MonoBehaviour , IViewOver
{
		#region IViewOver implementation

    public void fireSelect ()
    {
    }

    public void fireAction ()
    {
        if (StateMachine.Instance.State == GameState.FindBox00){
            StateMachine.Instance.State1_BoxFound = true;
        }else if (StateMachine.Instance.State == GameState.FindBoxAgain01){
            StateMachine.Instance.State2_BoxFound = true;
            Destroy(this);
        }
    }

#endregion
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
