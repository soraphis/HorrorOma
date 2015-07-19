using UnityEngine;
using UnityEditor;

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


		#if UNITY_EDITOR
		void OnDrawGizmos(){
			Gizmos.color = Color.yellow;
			foreach (var l in fuses)
				//Handles.DrawLine (this.transform.position, l.transform.position);
				Gizmos.DrawLine (this.transform.position, l.transform.position);
		}
		#endif


    }
}