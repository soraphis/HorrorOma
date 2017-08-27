using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Water;

namespace Assets.Scripts
{
    class GameOver : MonoBehaviour
    {
        public Transform Water = null;
        public Transform Boiler = null;
        public Sprite TotBoxErtrunkenSprite = null;
        public Sprite TotErtrunkenSprite = null;
        public Sprite TotExplosionSprite = null;
        public Sprite TotStromSprite = null;

        private Transform player;
        private Image gameOverImage;

        public void KisteDestroyedUnderwater()
        {
            ShowDeathScreen(TotBoxErtrunkenSprite);
        }

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            Player.instance.onLevelLoad += UISceneLoaded;
            StateMachine.Instance.OnStateChanged += ExplosionNow;
        }

        void Update()
        {
        }

        private void ExplosionNow(GameState oldState, GameState newState)
        {
            if (newState != GameState.WaterRises04) return;

            // Tod per Explosion
            if (Vector3.Distance(player.position, Boiler.position) <= 10f)
            {
                Kill(DeathType.EXPLOSION);
            }
        }

        void ShowDeathScreen(Sprite sprite)
        {
            player.gameObject.GetComponent<FPController>().enabled = false;
            gameOverImage.sprite = sprite;
            gameOverImage.color = Color.white;
            Invoke("LoadAgain", 3);
        }

        void LoadAgain()
        {
            SceneManager.LoadScene(0);
        }

        void UISceneLoaded()
        {
            GameObject canvas = GameObject.FindGameObjectWithTag("UICanvas");
            //foreach(Transform t in canvas.GetComponentsInChildren<Transform>()){
            //    Debug.Log(t.gameObject.name);
            //}
            gameOverImage = canvas.transform.Find("ImageForWinOrLose").GetComponent<Image>();
        }

        public enum DeathType{
            EXPLOSION, HEARTHATTACK, DROWNING, ELECTRIFICATION
        }

        public void Kill(DeathType By) {
            switch (By){
                case(DeathType.ELECTRIFICATION):
                    ShowDeathScreen(TotStromSprite);
                break;
                case(DeathType.EXPLOSION):
                    ShowDeathScreen(TotExplosionSprite);
                break;
                // FIXME! - add more
                default:
                    ShowDeathScreen(TotErtrunkenSprite);
                break;
            }
        }
    }
}
