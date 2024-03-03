using PowerTools;
using UnityEngine;

namespace Core.Game.Common.Systems {
    public class MovementAnimator : MonoBehaviour {
        public SpriteAnim animator;
        public AnimationClip idleClip;
        public AnimationClip moveClip;


        public void Play(bool isMoving) {
            var current = isMoving ? moveClip : idleClip;

            if (!animator.IsPlaying(current))
                animator.Play(current);
        }
    }
}