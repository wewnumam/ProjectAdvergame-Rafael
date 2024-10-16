using DG.Tweening;
using UnityEngine;

namespace ProjectAdvergame.Utility
{
    public class Tweener_PressMe : MonoBehaviour
    {
        [SerializeField] private float punchScaleMultiplier = 1;
        [SerializeField] private float duration = 1;
        [SerializeField] private int vibrato = 1;
        [SerializeField] private float elasticity = 1;
        private Sequence sequence;

        private void OnEnable()
        {
            if (sequence == null)
                sequence = DOTween.Sequence();

            sequence.Append(transform.DOPunchScale(transform.localScale * punchScaleMultiplier, duration, vibrato, elasticity).SetLoops(-1));
        }

        private void OnDisable()
        {
            sequence.Kill();
        }
    }
}