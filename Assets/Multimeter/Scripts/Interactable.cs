using System;
using UnityEngine;

namespace Multimeter.Scripts
{
    [RequireComponent(typeof(Outline))]
    public abstract class Interactable : MonoBehaviour
    {
        protected bool _isFocus;
        private Outline _outline;

        private void OnEnable()
        {
            _outline = GetComponent<Outline>();
            _outline.OutlineWidth = 0;
            _isFocus = false;
        }

        public void OnHoverEnter()
        {
            _isFocus = true;
            _outline.OutlineWidth = 10;
        }

        public void OnHoverExit()
        {
            _isFocus = false;
            _outline.OutlineWidth = 0;
        }
    }
}