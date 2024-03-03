using PowerTools;
using UnityEngine;

namespace Core.Game.Common.Systems {
    public class Movement : MonoBehaviour {
        public Rigidbody2D body;
        public new SpriteRenderer renderer;
        public float speed = 1f;

        public SpriteAnim animator;
        public AnimationClip idleClip;
        public AnimationClip moveClip;

        private static Vector2 Input => new(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
        private AnimationClip CurrentAnimation => Input == Vector2.zero ? idleClip : moveClip;


        public void FixedUpdate() {
            body.velocity = Input * speed;

            if (!animator.IsPlaying(CurrentAnimation))
                animator.Play(CurrentAnimation);

            if (Input != Vector2.zero)
                renderer.flipX = Input.x > 0;
        }
    }
}