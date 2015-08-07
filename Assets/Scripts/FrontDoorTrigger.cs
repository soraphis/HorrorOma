using System;
using UnityEditorInternal;
using UnityEngine;

namespace Assets.Scripts
{
    class FrontDoorTrigger : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            if (StateMachine.Instance.State == GameState.FindBox01)
            {
                if (!other.gameObject.tag.Equals("Kiste")) return;
                StateMachine.Instance.State1_BoxAtFrontDoor = true;
            }

        }

        private void OnTriggerExit(Collider other)
        {
            if (StateMachine.Instance.State == GameState.FindBox01)
            {
                if (!other.gameObject.tag.Equals("Kiste")) return;
                StateMachine.Instance.State1_BoxAtFrontDoor = false;
            }

        }
    }
}