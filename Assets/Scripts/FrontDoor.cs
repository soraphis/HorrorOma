using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts
{
    class FrontDoor : MonoBehaviour, IViewOver
    {
        public FrontDoorTrigger Trigger= null;

        public void fireAction()
        {
            if(StateMachine.Instance.State == GameState.FindBox01) { 

                Assert.IsNotNull(Trigger);

                if (!Trigger.IsBoxWithinCollider) return;

                var kiste = GameObject.FindWithTag("Kiste");
                var kisteTransform = kiste.GetComponent<Transform>();
                kisteTransform.localPosition = new Vector3(18.417f, 1.255f, -7.81f);

                StateMachine.Instance.State = GameState.FindBoxAgain02;
            }
        }

        public void fireSelect()
        {

        }
    }
}
