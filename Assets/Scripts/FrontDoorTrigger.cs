using UnityEngine;

namespace Assets.Scripts
{
    internal class FrontDoorTrigger : MonoBehaviour
    {
        public bool IsBoxWithinCollider { get; private set; }

        private void OnEnable()
        {
            IsBoxWithinCollider = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.tag.Equals("Kiste")) return;
            IsBoxWithinCollider = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.tag.Equals("Kiste")) return;
            IsBoxWithinCollider = false;
        }
    }
}