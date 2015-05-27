using UnityEngine;
using System.Collections;

public class DoorBehaviour : StateMachineBehaviour {

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		/*
		if (stateInfo.IsName ("DoorOpen")) {
			animator.SetBool ("open", false);
			Quaternion q = animator.transform.localRotation;
			q *= Quaternion.AngleAxis(-45, Vector3.up);
			animator.transform.localRotation = q;
			Debug.Log("door opened");
		} else if (stateInfo.IsName ("DoorClose")) {
			animator.SetBool ("open", true);
			Quaternion q = animator.transform.localRotation;
			q *= Quaternion.AngleAxis(90, Vector3.up);
			animator.transform.localRotation = q;
			Debug.Log("door closed");
		}
		*/
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
