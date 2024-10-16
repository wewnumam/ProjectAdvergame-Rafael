using UnityEngine;
using UnityEngine.Video;

namespace ProjectAdvergame.Module.ActionPlayer
{
    [CreateAssetMenu(fileName = "ActionItem_", menuName = "ProjectAdvergame/ActionItem")]
    public class SO_ActionItem : ScriptableObject
    {
        public VideoClip videoClip;
        public string message;
        public float stopTime;
    }
}
