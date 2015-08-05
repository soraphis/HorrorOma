using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    internal class FrontDoorScrewed : MonoBehaviour
    {
        public Transform Position;
        public AudioClip Audio;
        public GameObject[] Holzbretter = null;

        private void OnTriggerEnter(Collider other)
        {
            if (StateMachine.Instance.State != GameState.FindBoxAgain02 || Player.instance.inhand != Player.instance.BOX)
                return;

            AudioSource.PlayClipAtPoint(Audio, Position.position);
            foreach (var holzbrett in Holzbretter)
            {
                holzbrett.SetActive(true);
            }
            StateMachine.Instance.State = GameState.FindeWerkzeuge03;
            Destroy(gameObject);
        }
    }
}
