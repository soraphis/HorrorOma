using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Raycast von der MainCamera nach vorne um alle Scripte die IViewOver implementieren auszuführen.
    /// </summary>
    class ViewSystem : MonoBehaviour
    {
        private Transform _playerCameraTransform;

        void OnEnable()
        {
            _playerCameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        }

        void Update()
        {
            RaycastHit hit;
			Debug.DrawRay (_playerCameraTransform.position, _playerCameraTransform.forward * 3);
			if (!Physics.Raycast(new Ray(_playerCameraTransform.position, _playerCameraTransform.forward), out hit)) return;

            var scripts = hit.collider.gameObject.GetComponents<MonoBehaviour>();
            foreach (var clickable in scripts.OfType<IViewOver>())
            {
                clickable.OnViewOver(hit.distance);
            }
        }
    }
}
