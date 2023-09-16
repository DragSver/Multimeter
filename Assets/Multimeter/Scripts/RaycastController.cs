using UnityEngine;

namespace Multimeter.Scripts
{
    public class RaycastController : MonoBehaviour
    {
        private Camera _mainCamera;
        private Interactable _previousInteractable;

        private void OnEnable()
        {
            _mainCamera = GetComponent<Camera>();
        }

        protected void Update()
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500))
            {
                var interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    if (interactable != _previousInteractable)
                    {
                        _previousInteractable = interactable;
                        _previousInteractable.OnHoverEnter();
                    }
                }
                else if (_previousInteractable != null)
                {
                    _previousInteractable.OnHoverExit();
                    _previousInteractable = null;
                }
            }
            if (!Physics.Raycast(ray, out hit, 500) && _previousInteractable != null)
            {
                _previousInteractable.OnHoverExit();
                _previousInteractable = null;
            }
        }
    }
}