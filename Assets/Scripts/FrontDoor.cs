using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class FrontDoor : MonoBehaviour, IViewOver
    {
        public FrontDoorTrigger Trigger= null;

        private Vector3 boxStartPosition;

        public void fireAction()
        {
            if(StateMachine.Instance.State == GameState.FindBox01) { 

                if (!Trigger.IsBoxWithinCollider) return;

                var kiste = GameObject.FindWithTag("Kiste");
                kiste.transform.localPosition = boxStartPosition;

                StateMachine.Instance.State = GameState.FindBoxAgain02;
            }
        }

        public void fireSelect()
        {

        }

        void Start(){
            var kiste = GameObject.FindWithTag("Kiste");
            boxStartPosition = kiste.transform.localPosition;
        }
    }
}
