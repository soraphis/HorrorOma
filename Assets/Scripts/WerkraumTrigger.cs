using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class WerkraumTrigger : MonoBehaviour
    {
        public Transform Water = null;
        //private const float speed = 1/60f;
        private float slowness = 45f; // inverse of speed
        private float slownessInc = 5.0f;

        private void OnTriggerEnter(Collider other)
        {
            if (StateMachine.Instance.State == GameState.FindeWerkzeuge03)
            {
                StateMachine.Instance.State = GameState.WaterBoiler04;
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
            }
        }
    }
}
