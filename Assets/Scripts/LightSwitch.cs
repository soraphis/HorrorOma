using UnityEngine;

namespace Assets.Scripts
{
    internal class LightSwitch : MonoBehaviour, IViewOver
    {
		#region IViewOver implementation

		public void fireSelect ()
		{
		}

		public void fireAction ()
		{
			foreach (Fuse fuse in fuses) {
				fuse.powered = !fuse.powered;
			}
		}

		#endregion

		// contains all lamps which may have multiple lightobjects
		public Fuse[] fuses = null;



    }
}