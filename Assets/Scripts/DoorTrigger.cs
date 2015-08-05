using UnityEngine;


/*
 * Place this at the door handle
 */
public class DoorTrigger  : MonoBehaviour, IViewOver {

#region IViewOver implementation
	public void fireSelect ()
    {

    }

    public void fireAction ()
    {
        this.Door.GetComponent<DoorOpen>().Trigger();
    }
	#endregion

    public GameObject Door;

    void Start(){
        this.Door = this.transform.parent.Find("Tuer").gameObject;
    }

}
