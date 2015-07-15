using UnityEngine;

namespace Assets.Scripts
{
    internal class LightSwitch : MonoBehaviour, IViewOver
    {
        public GameObject[] Lights;

        public void OnViewOver(float distance)
        {
            if (!Input.GetButtonDown("Fire1")) return;

            foreach (var myGameObject in Lights)
            {
                foreach (var myLight in myGameObject.GetComponentsInChildren<Light>(true))
                {
                    myLight.enabled = !myLight.enabled;
                }
            }
        }
    }
}