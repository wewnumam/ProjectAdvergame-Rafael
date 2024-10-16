using Agate.MVC.Base;
using DG.Tweening;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjectAdvergame.Module.QuizPlayer
{
    public class QuizPlayerController : ObjectController<QuizPlayerController, QuizPlayerModel, IQuizPlayerModel, QuizPlayerView>
    {
        private int _wrongCount;
        private int _answersCount;

        public override void SetView(QuizPlayerView view)
        {
            base.SetView(view);
            view.currentItem = view.items[0];
            view.questionText.SetText(view.currentItem.question);

            _answersCount = view.items.Sum(item => item.answers.Count);
            Debug.Log(_answersCount);

            for (int i = 0; i < view.currentItem.answers.Count; i++)
            {
                Answer answer = view.currentItem.answers[i];
                
                GameObject obj = GameObject.Instantiate(view.answerButtonTemplate.gameObject, view.answerButtonParent);
                obj.GetComponentInChildren<TMP_Text>().SetText(answer.message);
                
                Button button = obj.GetComponentInChildren<Button>();
                view.buttons.Add(button);
                
                button.onClick.AddListener(() => AnswerCheck(view.buttons.IndexOf(button)));
                
                obj.SetActive(true);
            }

            view.videoPlayer.clip = view.currentItem.videoClip;
            view.videoPlayer.Play();
        }

        public void AnswerCheck(int answerIndex)
        {
            EventSystem.current.SetSelectedGameObject(null);
            if (_view.currentItem.answers[answerIndex].isCorrect)
            {
                _view.feedbackImage.DOColor(_view.correctColor, 1).OnComplete(() => _view.feedbackImage.DOColor(_view.normalColor, .5f));
                SetNextQuizItem();
            }
            else
            {
                _wrongCount++;
                _view.feedbackImage.DOColor(_view.wrongColor, 1).OnComplete(() => _view.feedbackImage.DOColor(_view.normalColor, .5f));
                _view.buttons[answerIndex].gameObject.SetActive(false);
            }

            float percentage = (float)(_answersCount - _wrongCount) / (float)_answersCount;
            _view.scoreText?.SetText($"{percentage * 100f:F2}%");
            Debug.Log($"{_wrongCount} {_answersCount} {percentage}");
        }

        public void SetNextQuizItem()
        {
            _view.currentIndex++;
            if (_view.currentIndex > _view.items.Count - 1)
            {
                foreach (var button in _view.buttons)
                    button.gameObject.SetActive(false);

                _view.onGameEnd?.Invoke();
            }
            else
            {
                _view.currentItem = _view.items[_view.currentIndex];
                _view.questionText.SetText(_view.currentItem.question);

                for (int i = 0; i < _view.currentItem.answers.Count; i++)
                {
                    Answer item = _view.currentItem.answers[i];
                    
                    _view.videoPlayer.clip = _view.currentItem.videoClip;
                    _view.videoPlayer.Play();

                    _view.buttons[i].GetComponentInChildren<TMP_Text>().SetText(item.message);
                    _view.buttons[i].gameObject.SetActive(true);
                }
            }
        }
    }
}