using System.Collections;
using UnityEngine;

public class FrontDoorHandle : MonoBehaviour, IViewOver {

#region IViewOver implementation

    public void fireSelect ()
    {
    }

    public void fireAction ()
    {
        if(StateMachine.Instance.State == GameState.FindBox00 || !StateMachine.Instance.State2_BoxFound)
            NotificationText.SimpleScreenText("(Ich sollte den Keller nicht ohne Kiste verlassen)");
        else
            NotificationText.SimpleScreenText("(Die Tür ist verschraubt, ich muss sie irgendwie öffnen)");
    }

#endregion

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
