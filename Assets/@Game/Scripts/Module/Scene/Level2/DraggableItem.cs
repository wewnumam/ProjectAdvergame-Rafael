using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using ProjectTA.Utility;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Canvas canvas;
    private DragManager dragManager; // Reference to the manager

    private Vector2 originalPosition; // Store the original position of the item
    private DraggableItem collidedItem; // Store the item that we collided with
    public float swapSpeed = 5f; // Speed for smooth movement during the swap
    private bool isMoving = false; // Flag to prevent dragging during movement

    public void SetManager(DragManager manager)
    {
        dragManager = manager; // Set reference to the manager
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>(); // Reference the parent Canvas
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isMoving) return;

        originalPosition = rectTransform.anchoredPosition; // Store original position before dragging
        canvasGroup.alpha = 0.6f; // Make the item semi-transparent while dragging
        canvasGroup.blocksRaycasts = false; // Ignore raycasts so it can be dropped
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isMoving) return;

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; // Adjust position

        CheckForCollision(); // Check for collisions during dragging
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isMoving) return;

        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;

        if (collidedItem != null)
        {
            StartCoroutine(SmoothSwap(collidedItem));
        }
        else
        {
            StartCoroutine(SmoothMove(originalPosition));
        }
    }

    private void CheckForCollision()
    {
        DraggableItem[] allDraggableItems = FindObjectsOfType<DraggableItem>();

        foreach (DraggableItem item in allDraggableItems)
        {
            if (item != this)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(item.rectTransform, Input.mousePosition, canvas.worldCamera))
                {
                    collidedItem = item;
                    return;
                }
            }
        }

        collidedItem = null;
    }

    private IEnumerator SmoothMove(Vector2 targetPosition)
    {
        isMoving = true;

        while (Vector2.Distance(rectTransform.anchoredPosition, targetPosition) > 0.1f)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, targetPosition, Time.deltaTime * swapSpeed);
            yield return null;
        }

        rectTransform.anchoredPosition = targetPosition;
        isMoving = false;
    }

    private IEnumerator SmoothSwap(DraggableItem otherItem)
    {
        isMoving = true;

        // Store the original positions of both items
        Vector2 otherOriginalPosition = otherItem.rectTransform.anchoredPosition;
        int mySiblingIndex = rectTransform.GetSiblingIndex();
        int otherSiblingIndex = otherItem.rectTransform.GetSiblingIndex();

        // Move both items to their new positions smoothly
        Coroutine otherItemMove = StartCoroutine(otherItem.SmoothMove(originalPosition));
        yield return StartCoroutine(SmoothMove(otherOriginalPosition));

        // Ensure the other item's movement coroutine finishes before ending
        yield return otherItemMove;

        // Swap the sibling indexes to update the hierarchy order
        rectTransform.SetSiblingIndex(otherSiblingIndex);
        otherItem.rectTransform.SetSiblingIndex(mySiblingIndex);

        // Notify the manager to update the order after the swap
        dragManager.UpdateOrder();

        isMoving = false;
    }

}
