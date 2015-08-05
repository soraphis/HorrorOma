using UnityEngine;
using UnityEditor;
using Assets.Scripts;

public class BoilerExplode : MonoBehaviour {
	public bool Sleep = true;
	private float countDown = 15;
	public AudioClip Audio;
	public Transform Position;

	void Update(){
		if (Sleep)
			return;
		if(StateMachine.Instance.State == GameState.WaterBoiler04){
			countDown -= Time.deltaTime;
			if (countDown <= 0) {
				Debug.Log ("EXPLOSION");
				AudioSource.PlayClipAtPoint(Audio, Position.position);
				StateMachine.Instance.State = GameState.WaterRises05;
				Sleep = true;

			}
			
		}

	}
	
	#if UNITY_EDITOR
	void OnDrawGizmos(){
		Gizmos.DrawLine (this.transform.position, this.transform.position + Vector3.up * countDown / 10F);
	}
#endif
}
