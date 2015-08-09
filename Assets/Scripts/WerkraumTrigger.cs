using System;
using System.Collections;
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
        public GameObject[] ActivateGameObjects = null;
        public GameObject[] DeactivateGameObjects = null;
        private Image flashImage;

        private void OnTriggerEnter(Collider other)
        {
            if (StateMachine.Instance.State == GameState.FindeWerkzeuge02)
            {
                StateMachine.Instance.State = GameState.WaterBoiler03;
                flashImage.color = Color.white; // alpha should be 1

                foreach (var gameObj in ActivateGameObjects)
                {
                    if(gameObj == null){
                        Debug.Log("GameObject reference is null");
                        continue;
                    }
                    gameObj.SetActive(true);
                }
                foreach (var gameObj in DeactivateGameObjects)
                {
                    if(gameObj == null){
                        Debug.Log("GameObject reference is null");
                        continue;
                    }
                    gameObj.SetActive(false);
                }

                StartCoroutine(FlashScreen());
                WaterSystem.instance.WaterIncrease1 = true;
            }
        }

        private IEnumerator FlashScreen(){
            Color c = flashImage.color;
            for(float f = 1f; f >= 0; f -= 0.5f * Time.deltaTime){
                c.a = f;
                flashImage.color = c;
                yield return null;
            }
            c.a = 0;
            flashImage.color = c;
            GameObject.Destroy(this); // this should be the last things, this script does
        }


        void UISceneLoaded(){
            GameObject canvas = GameObject.FindGameObjectWithTag("UICanvas");
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
        }
    }
}
