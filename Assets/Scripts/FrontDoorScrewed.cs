using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    internal class FrontDoorScrewed : MonoBehaviour
    {
        public Transform FrontDoor = null;
        public AudioClip Audio  = null;
        public GameObject[] Holzbretter = null;

        void OnTriggerEnter(Collider other)
        {
            if (StateMachine.Instance.State != GameState.FindBoxAgain02 || Player.instance.inhand != Player.instance.BOX)
                return;

            DoorOpen d = FrontDoor.GetComponentInChildren<DoorOpen>();
            if(d.Open) d.Trigger();
            d.locked = true;

            AudioSource.PlayClipAtPoint(Audio, this.FrontDoor.position);
            foreach (var holzbrett in Holzbretter)
            {
                holzbrett.SetActive(true);
            }

            StateMachine.Instance.State = GameState.FindeWerkzeuge03;
            Destroy(gameObject);
        }
    }
}
