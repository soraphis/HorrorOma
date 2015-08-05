using UnityEngine;
using UnityEditor;
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
			fuse.powered = false;
			fuse.PowerAble = !fuse.PowerAble;
		}
        if(Boiler != null)
			Boiler.GetComponent<BoilerExplode> ().Sleep = false;
	}

	#endregion
	public GameObject Boiler = null;
	// contains all lamps which may have multiple lightobjects
	public Fuse[] fuses = null;

}