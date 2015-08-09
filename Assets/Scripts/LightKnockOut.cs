using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
// Use this for initialization
class LightKnockOut : MonoBehaviour, IViewOver
{
	#region IViewOver implementation

	public void fireSelect ()
	{
	}

	public void fireAction ()
	{
		foreach (Fuse fuse in fuses) {
			fuse.PowerAble = !fuse.PowerAble;
            fuse.RefreshItems();
		}
        if (StateMachine.Instance.State == GameState.WaterBoiler03){
            GetComponent<AudioSource>().Play();
            if(Boiler != null)
                Boiler.GetComponent<BoilerExplode>().Sleep = false;
        }
	}

	#endregion
	public GameObject Boiler = null;
	// contains all lamps which may have multiple lightobjects
	public Fuse[] fuses = null;

}