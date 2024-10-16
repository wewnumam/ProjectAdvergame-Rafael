using Agate.MVC.Core;
using DG.Tweening;
using ProjectTA.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MixController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] Image indicator;
    [SerializeField] Color normalColor;
    [SerializeField] Color correctColor;
    [SerializeField] Color wrongColor;

    [SerializeField] List<GameObject> points;
    private int currentPointIndex;
    private Vector2 initialAnchoredPosition;

    [SerializeField] UnityEvent onWin;
    [SerializeField] UnityEvent onLose;

    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();  // Get the canvas for proper screen positioning
        initialAnchoredPosition = rectTransform.anchoredPosition;
        points[0].SetActive(true);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Optional: Lower the alpha or make it non-interactable to other UI elements while dragging
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0.6f;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Move the UI element with the pointer
        if (canvas != null)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Optional: Restore the alpha or make it interactable again after dragging
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.TAG_BARRIER))
        {
            indicator.DOColor(wrongColor, .25f).OnComplete(() => indicator.DOColor(normalColor, .5f));
            Reset();
            onLose?.Invoke();
        }

        if (collision.CompareTag(TagManager.TAG_POINT))
        {
            collision.gameObject.SetActive(false);
            indicator.DOColor(correctColor, .25f).OnComplete(() => indicator.DOColor(normalColor, .5f));
            currentPointIndex++;
            if (currentPointIndex >= points.Count)
                onWin?.Invoke();
            else
                points[currentPointIndex].gameObject.SetActive(true);
        }
    }

    public void Reset()
    {
        rectTransform.anchoredPosition = initialAnchoredPosition;
        currentPointIndex = 0;

        for (int i = 0; i < points.Count; i++)
        {
            GameObject point = points[i];
            point.SetActive(i == 0);
        }
    }
}