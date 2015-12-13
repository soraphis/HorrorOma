using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class FrontDoor : MonoBehaviour, IViewOver
    {
        private Vector3 boxStartPosition;

        [SerializeField] private GameObject FrontDoorLight;
		[SerializeField] private DoodadExchange doodadExchange = null;

        public void fireAction()
        {
            if (StateMachine.Instance.State == GameState.FindBox00) {
                if (!StateMachine.Instance.State1_BoxAtFrontDoor) return;

                StartCoroutine(DisplayceBox());

                StateMachine.Instance.State = GameState.FindBoxAgain01;
				doodadExchange.Exchange(2);
				doodadExchange.AddDecalLayer(2);
            }
        }

        public void fireSelect()
        {

        }

        IEnumerator DisplayceBox(){
            var kiste = GameObject.FindWithTag("Kiste");
            LightFlicker lf;
            if( FrontDoorLight != null){
                lf = FrontDoorLight.GetComponent<LightFlicker>();
                lf.ForceFlicker(2);
            }
            yield return new WaitForSeconds(1.4f);
            kiste.transform.localPosition = boxStartPosition;

        }

        void Start(){
            var kiste = GameObject.FindWithTag("Kiste");
            boxStartPosition = kiste.transform.localPosition;
        }
    }
}
