using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjectAdvergame.Utility
{
    public class CursorChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private Texture2D normalCursor;
        [SerializeField] private Texture2D hoverCursor;
        [SerializeField] private Texture2D clickCursor;
        [SerializeField] private Vector2 hotSpot = Vector2.zero;
        [SerializeField] private CursorMode cursorMode = CursorMode.Auto;

        private void Start()
        {
            // Set the normal cursor at the start
            Cursor.SetCursor(normalCursor, hotSpot, cursorMode);
        }

        private void OnDisable()
        {
            Cursor.SetCursor(normalCursor, hotSpot, cursorMode);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            // Set cursor when pointer enters the object
            Cursor.SetCursor(hoverCursor, hotSpot, cursorMode);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            // Set cursor back to normal when pointer exits the object
            Cursor.SetCursor(normalCursor, hotSpot, cursorMode);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            // Set cursor when pointer is clicked on the object
            Cursor.SetCursor(clickCursor, hotSpot, cursorMode);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            // Set cursor back to hover when the pointer is released
            Cursor.SetCursor(hoverCursor, hotSpot, cursorMode);
        }
    }
}