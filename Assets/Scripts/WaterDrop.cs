using UnityEngine;
using System.Collections;

public class WaterDrop : MonoBehaviour {
	private const float speedMinus = 1/25f;
	public Transform Water;

	// Update is called once per frame
	void Update () {
		if (StateMachine.Instance.State == GameState.WaterDrops06 && Water.position.y > 0) {
			Water.position = new Vector3 (Water.position.x, Water.position.y - (Time.deltaTime * speedMinus), Water.position.z);
		}

		if (Water.position.y <= 0) {
			Water.gameObject.SetActive(false);
		}
	}
}
