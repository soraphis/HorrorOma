using Mono.Xml.Xsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityStandardAssets.Water;

namespace Assets.Scripts
{
    class WerkraumTrigger : MonoBehaviour
    {
        public Transform Water = null;
        //private const float speed = 1/60f;
        private float slowness = 45f; // inverse of speed
        private float slownessInc = 5.0f;
        public GameObject[] ActivateGameObjects = null;
        public GameObject[] DeactivateGameObjects = null;
        private Image flashImage;
        private bool flash = false;
        private const float flashSlowness = 2f;

        private void OnTriggerEnter(Collider other)
        {
            if (StateMachine.Instance.State == GameState.FindeWerkzeuge03)
            {
                StateMachine.Instance.State = GameState.WaterBoiler04;
                flash = true;
                flashImage.color = Color.white; // alpha should be 1



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

        void UISceneLoaded(){
            GameObject canvas = GameObject.FindGameObjectWithTag("UICanvas");
            //foreach(Transform t in canvas.GetComponentsInChildren<Transform>()){
            //    Debug.Log(t.gameObject.name);
            //}
            flashImage = canvas.transform.Find("GamestateObjects/Panel").GetComponent<Image>();
            if(flashImage == null){
                Debug.Log("image not found");
            }
        }

        void Start(){
            Player.instance.onLevelLoad += UISceneLoaded;
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
                    Color c = flashImage.color;
                    c.a = c.a - (Time.deltaTime * 1/flashSlowness);
                    if (c.a <= 0)
                    {
                        c.a = 0;
                        flash = false;
                    }
                    flashImage.color = c;
                }
            }
        }
    }
}
