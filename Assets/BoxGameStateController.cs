using System.Collections;
using UnityEditorInternal;
using UnityEngine;

public class BoxGameStateController : MonoBehaviour , IViewOver
{
		#region IViewOver implementation

    public void fireSelect ()
    {
    }

    public void fireAction ()
    {
        if (StateMachine.Instance.State == GameState.FindBox01){
            StateMachine.Instance.State1_BoxFound = true;
            Debug.Log("a");
        }else if (StateMachine.Instance.State == GameState.FindBoxAgain02){
            StateMachine.Instance.State2_BoxFound = true;
            Debug.Log("b");
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
