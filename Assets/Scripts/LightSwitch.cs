using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

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
            GetComponent<AudioSource>().Play();
		}

		#endregion

		// contains all lamps which may have multiple lightobjects
		public Fuse[] fuses = null;


		#if UNITY_EDITOR
		void OnDrawGizmosSelected(){
			Gizmos.color = Color.yellow;
			foreach (var l in fuses)
				//Handles.DrawLine (this.transform.position, l.transform.position);
				Gizmos.DrawLine (this.transform.position, l.transform.position);
		}
		#endif


    }
}