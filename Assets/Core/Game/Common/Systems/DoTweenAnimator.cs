using DG.Tweening;
using UnityEngine;

namespace Core.Game.Common.Systems {
    public class DoTweenAnimator : MonoBehaviour {
        private Tween _tween;
        private Sequence Sequence { get; set; }


        public void Play(Tween tween) {
            if (_tween == tween)
                return;

            _tween = tween;
            Sequence?.Kill();
            
            Sequence = DOTween.Sequence();
            Sequence.Append(tween).SetLoops(-1, LoopType.Yoyo);
            Debug.Log($"Play {tween.id}, seq: {Sequence.id}");
        }
    }
}