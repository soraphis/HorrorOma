using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class WerkraumTrigger : MonoBehaviour
    {
        public Transform Water;
        private const float speed = 1/60f;

        private void OnTriggerEnter(Collider other)
        {
            if (StateMachine.Instance.State == GameState.FindeWerkzeuge03)
            {
                StateMachine.Instance.State = GameState.WaterBoiler04;
            }
        }

        private void Update()
        {
            if (StateMachine.Instance.State == GameState.WaterBoiler04 && Water.position.y <= 0.95)
            {
                Water.gameObject.SetActive(true);
                Water.position = new Vector3(Water.position.x, Water.position.y + (Time.deltaTime * speed), Water.position.z);
            }
        }
    }
}
