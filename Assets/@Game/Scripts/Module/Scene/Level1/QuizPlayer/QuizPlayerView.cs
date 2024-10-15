using Agate.MVC.Base;
using NaughtyAttributes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;

namespace ProjectAdvergame.Module.QuizPlayer
{
    public class QuizPlayerView : ObjectView<IQuizPlayerModel>
    {
        [Header("View")]
        public VideoPlayer videoPlayer;
        public TMP_Text questionText;
        public Transform answerButtonParent;
        public Button answerButtonTemplate;

        [Header("Feedback")]
        public Image feedbackImage;
        public Color normalColor;
        public Color wrongColor;
        public Color correctColor;

        [Header("Model")] 
        public List<SO_QuizItem> items;
        [ReadOnly] public List<Button> buttons;
        [ReadOnly] public SO_QuizItem currentItem;
        [ReadOnly] public int currentIndex;

        [Header("GameEnd")]
        public TMP_Text scoreText;
        public UnityEvent onGameEnd;

        protected override void InitRenderModel(IQuizPlayerModel model)
        {
        }

        protected override void UpdateRenderModel(IQuizPlayerModel model)
        {
        }
    }
}