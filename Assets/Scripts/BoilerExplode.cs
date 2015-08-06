using UnityEngine;
using UnityEditor;
using Assets.Scripts;

public class BoilerExplode : MonoBehaviour {

    public bool Sleep = true;
	private float countDown = 15;

	void Update(){
		if (Sleep)
			return;
		if(StateMachine.Instance.State == GameState.WaterBoiler04){
			countDown -= Time.deltaTime;
			if (countDown <= 0) {
				Debug.Log ("EXPLOSION");
				gameObject.SendMessage("DamageRequest");
				GetComponentInChildren<AudioSource>().Play();
				StateMachine.Instance.State = GameState.WaterRises05;

                WaterSystem.instance.WaterIncrease2 = true;

				Destroy(this); // should destroy this script
                Sleep = true; // should not be necessary
			}
			
		}

	}
	
	#if UNITY_EDITOR
	void OnDrawGizmos(){
		Gizmos.DrawLine (this.transform.position, this.transform.position + Vector3.up * countDown / 10F);
	}
#endif
}
