using Agate.MVC.Base;
using Agate.MVC.Core;
using DG.Tweening;
using ProjectAdvergame.Module.QuizPlayer;
using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace ProjectAdvergame.Module.ActionPlayer
{
    public class ActionPlayerController : ObjectController<ActionPlayerController, ActionPlayerModel, IActionPlayerModel, ActionPlayerView>
    {
        public override void SetView(ActionPlayerView view)
        {
            base.SetView(view);
            view.currentItem = view.items[0].item;
            view.messageText.SetText(view.currentItem.message);
            view.videoPlayer.clip = view.currentItem.videoClip;
            view.videoPlayer.loopPointReached += OnNextAction;
            view.videoPlayer.Play();
            view.SetPause();
            view.SetCallBacks(OnNextAction, OnPause, OnResume, OnAddFailCount);
        }

        private void OnNextAction(VideoPlayer source)
        {
            OnNextAction();
        }

        private void OnPause()
        {
            _view.items[_view.currentIndex].onPause?.Invoke();
            _view.videoPlayer.Pause();
        }

        private void OnResume()
        {
            _view.items[_view.currentIndex].onResume?.Invoke();
            _view.videoPlayer.Play();
        }

        private void OnNextAction()
        {
            _view.currentIndex++;
            if (_view.currentIndex > _view.items.Count - 1)
            {
                _view.videoPlayer.Stop();
                _view.onGameEnd?.Invoke();
            }
            else
            {
                _view.currentItem = _view.items[_view.currentIndex].item;
                _view.messageText.SetText(_view.currentItem.message);
                _view.videoPlayer.clip = _view.currentItem.videoClip;
                _view.videoPlayer.Play();
                _view.SetPause();
            }
        }

        private void OnAddFailCount()
        {
            _view.failCount++;
            _view.failCountText.SetText($"{_view.failCount}↕");
        }
    }
}