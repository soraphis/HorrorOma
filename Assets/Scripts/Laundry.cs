using UnityEngine;
using System.Collections;

public class Laundry : MonoBehaviour, IViewOver {
	#region IViewOver implementation
	
	public void fireSelect ()
	{
	}
	
	public void fireAction ()
	{
		if (Water.position.y > 0) {
			StateMachine.Instance.State = GameState.WaterDrops06;
		}

	}
	
	#endregion

	public Transform Water;
	private const float speed = 1/30f;

	// Update is called once per frame
	void Update () {
		if (StateMachine.Instance.State == GameState.WaterRises05 && Water.position.y <= 2.0)
		{
			Water.position = new Vector3(Water.position.x, Water.position.y + (Time.deltaTime * speed), Water.position.z);
		}
	}
}
