using DG.Tweening;
using ProjectAdvergame.Module.ActionPlayer;
using ProjectTA.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class KnifeController : MonoBehaviour
{
    [Header("Bars"), SerializeField] RectTransform bars;
    [SerializeField] List<GameObject> barObjs;
    [SerializeField] RectTransform endPoint;
    [SerializeField] float duration;
    [SerializeField] UnityEvent onWin;
    [SerializeField] UnityEvent onLose;

    private bool noteInRange = false;
    private GameObject currentBarObj;
    private int currentBarsCount;
    private bool isWin;

    private void Start()
    {
        MoveBars();
    }

    private void MoveBars()
    {
        foreach (var bar in barObjs)
        {
            bar.SetActive(true);
            if (bar.TryGetComponent<Image>(out var image))
                image.color = Color.white;
        }
        bars.anchoredPosition = Vector3.zero;
        bars.DOAnchorPos(endPoint.anchoredPosition, duration).SetEase(Ease.Linear).OnComplete(() => {
            if (!isWin)
            {
                onLose?.Invoke();
                currentBarsCount = 0;
                MoveBars();
            }
        });
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.CompareTag(TagManager.TAG_SLICEBAR))
        {
            noteInRange = true;
            currentBarObj = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.TAG_SLICEBAR))
        {
            noteInRange = false;
            currentBarObj = null;
            if (collision.TryGetComponent<Image>(out var image))
                image.color = Color.red;
        }
    }

    public void Slice()
    {
        
        if (noteInRange)
        {
            Debug.Log("Perfect hit!");
            currentBarObj.SetActive(false);
            currentBarsCount++;
            if (currentBarsCount >= barObjs.Count)
            {
                onWin?.Invoke();
                isWin = true;
            }
        }
        else
        {
            Debug.Log("Missed!");
        }
    }
}
