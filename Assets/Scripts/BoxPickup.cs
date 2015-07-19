using UnityEngine;
using System.Collections;


public class BoxPickup : MonoBehaviour, IViewOver {

	#region IViewOver implementation

	public void fireSelect ()
	{

	}

	public void fireAction ()
	{
		Player.instance.inhand = Player.instance.BOX;
		Player.instance.inhand.PickDrop ();
	}

	#endregion


}
