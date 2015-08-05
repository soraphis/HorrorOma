using UnityEngine;
using UnityEditor;
namespace Assets.Scripts
{
	// Use this for initialization
	internal class LightKnockOut : MonoBehaviour, IViewOver
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
			Boiler.GetComponent<BoilerExplode> ().Sleep = false;
		}
		
		#endregion
		public GameObject Boiler;
		// contains all lamps which may have multiple lightobjects
		public Fuse[] fuses = null;

	}
}