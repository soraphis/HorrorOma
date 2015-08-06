using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class WaterDamage : MonoBehaviour
    {
        public GameObject Water = null;

        internal class Variablen {
            protected internal float DamagePerSecond = 0.2f;
            protected internal float Health = 1.0f;

            private static Variablen instance;

            private Variablen() { }

            public static Variablen Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new Variablen();
                    }
                    return instance;
                }
            }
        }
        protected internal Variablen Vars = Variablen.Instance;

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
            {
                TakeDamage();
            }
        }

        void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
            {
                TakeDamage();
            }
        }

        void TakeDamage()
        {
            Vars.Health -= Time.deltaTime * Vars.DamagePerSecond;
            if (Vars.Health <= 0)
            {
                GameObject.FindWithTag("Player").GetComponent<GameOver>().KisteDestroyedUnderwater();
            }
        }
    }
}
