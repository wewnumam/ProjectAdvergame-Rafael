using Agate.MVC.Base;
using NaughtyAttributes;
using UnityEngine.Events;

namespace ProjectAdvergame.Module.GameplayState
{
    public class GameplayStateView : BaseView
    {
        public UnityEvent onPlay;
        public UnityEvent onEnd;

        private UnityAction onReady, onFinish;

        public void SetCallback(UnityAction onReady, UnityAction onFinish)
        {
            this.onReady = onReady;
            this.onFinish = onFinish;
        }

        [Button]
        public void SetPlay()
        {
            onReady?.Invoke();
        }

        [Button]
        public void SetEnd()
        {
            onFinish?.Invoke();
        }
    }
}