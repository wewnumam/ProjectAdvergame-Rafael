using Agate.MVC.Base;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

namespace ProjectAdvergame.Module.ActionPlayer
{
    public class ActionPlayerView : ObjectView<IActionPlayerModel>
    {
        public VideoPlayer videoPlayer;
        public TMP_Text messageText;
        [ReadOnly] public SO_ActionItem currentItem;
        [ReadOnly] public int currentIndex;
        public List<ActionItem> items;
        public UnityEvent onGameEnd;

        private UnityAction onNextAction;
        private UnityAction onPause;
        private UnityAction onResume;

        [Button]
        public void NextAction()
        {
            onNextAction?.Invoke();
        }

        [Button]
        public void Resume()
        {
            onResume?.Invoke();
        }

        public void SetCallBacks(UnityAction onNextAction, UnityAction onPause, UnityAction onResume)
        {
            this.onNextAction = onNextAction;
            this.onPause = onPause;
            this.onResume = onResume;
        }

        protected override void InitRenderModel(IActionPlayerModel model)
        {
        }

        protected override void UpdateRenderModel(IActionPlayerModel model)
        {
        }

        internal void SetPause()
        {
            StartCoroutine(SetPauseCoroutine());
        }

        private IEnumerator SetPauseCoroutine()
        {
            yield return new WaitForSeconds(currentItem.stopTime);
            onPause?.Invoke();
        }
    }

    [Serializable]
    public class ActionItem
    {
        public SO_ActionItem item;
        public UnityEvent onPause;
        public UnityEvent onResume;
    }
}