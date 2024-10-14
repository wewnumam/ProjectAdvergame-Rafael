using TMPro;
using UnityEngine;

namespace ProjectTA.Utility
{
    public class UIFollowObject : MonoBehaviour
    {
        public Transform targetObject;
        public Vector3 offset = Vector3.zero;
        public Camera mainCamera;
        private RectTransform rectTransform;
        private Vector3 targetPosition;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            if (mainCamera == null)
                mainCamera = Camera.main;
        }

        private void LateUpdate()
        {
            if (targetObject == null || mainCamera == null)
                return;

            targetPosition = targetObject.position + offset;
            Vector2 screenPoint = mainCamera.WorldToScreenPoint(targetPosition);

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform.parent as RectTransform, screenPoint, mainCamera, out Vector2 localPoint))
            {
                rectTransform.localPosition = localPoint;
            }
        }
    }
}