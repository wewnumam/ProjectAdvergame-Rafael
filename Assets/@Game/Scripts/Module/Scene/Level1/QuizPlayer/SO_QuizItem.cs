using ProjectTA.Utility;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace ProjectAdvergame.Module.QuizPlayer
{
    [CreateAssetMenu(fileName = "QuizItem_", menuName = "ProjectAdvergame/QuizItem")]
    public class SO_QuizItem : ScriptableObject
    {
        public VideoClip videoClip;
        public string question;
        public List<Answer> answers;
    }

    [System.Serializable]
    public class Answer
    {
        public string message;
        public bool isCorrect;
    }
}
