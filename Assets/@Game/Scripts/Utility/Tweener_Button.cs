using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace ProjectAdvergame.Utility
{
    public class Tweener_Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public float scaleUpFactor = 1.2f; 
        public float scaleDownFactor = 1f; 
        public float duration = 0.2f;

        public UnityEvent onEnter, onExit;

        private Vector3 originalScale;

        void Start()
        {
            originalScale = transform.localScale;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            // Scale up the button when hovered
            transform.DOScale(originalScale * scaleUpFactor, duration);
            onEnter?.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            // Scale back to original size when the pointer exits
            transform.DOScale(originalScale, duration);
            onExit?.Invoke();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            // Scale down the button when clicked
            transform.DOScale(originalScale * scaleDownFactor, duration);
        }
    }
}