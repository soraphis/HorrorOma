using UnityEngine;
using System.Collections;

public class LampPickup : MonoBehaviour, IViewOver {

	#region IViewOver implementation
	
	public void fireSelect ()
	{
		
	}
	
	public void fireAction ()
	{
		Player.instance.inhand = Player.instance.LAMP;
		Player.instance.inhand.PickDrop ();
	}
	
	#endregion
}
