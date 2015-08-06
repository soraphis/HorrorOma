using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Assertions;
using UnityStandardAssets.Water;

namespace Assets.Scripts
{
    class WerkraumTrigger : MonoBehaviour
    {
        public Transform Water = null;
        //private const float speed = 1/60f;
        private float slowness = 45f; // inverse of speed
        private float slownessInc = 5.0f;
        public GameObject[] ActivateGameObjects;
        public GameObject[] DeactivateGameObjects;
        public CanvasGroup WhiteCanvasGroupForFlash;
        private bool flash = false;
        private const float flashSlowness = 2f;

        private void OnTriggerEnter(Collider other)
        {
            if (StateMachine.Instance.State == GameState.FindeWerkzeuge03)
            {
                StateMachine.Instance.State = GameState.WaterBoiler04;
                flash = true;
                WhiteCanvasGroupForFlash.alpha = 1;


                foreach (var gameObj in ActivateGameObjects)
                {
                    gameObj.SetActive(true);
                }
                foreach (var gameObj in DeactivateGameObjects)
                {
                    gameObj.SetActive(false);
                }
            }
        }

        private void Update()
        {
            if(Water == null) return;
            if (StateMachine.Instance.State == GameState.WaterBoiler04 && Water.position.y <= 0.95f)
            {
                Water.gameObject.SetActive(true);
                Water.position = new Vector3(Water.position.x, Water.position.y + (Time.deltaTime * 1/slowness), Water.position.z);
                this.slowness += slownessInc;
                this.slownessInc *= 0.9375f;

                if (flash)
                {
                    WhiteCanvasGroupForFlash.alpha = WhiteCanvasGroupForFlash.alpha - (Time.deltaTime * 1/flashSlowness);
                    if (WhiteCanvasGroupForFlash.alpha <= 0)
                    {
                        WhiteCanvasGroupForFlash.alpha = 0;
                        flash = false;
                    }
                }
            }
        }
    }
}
