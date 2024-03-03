using UnityEngine;

namespace Core.Game.Common.Systems {
    public class Movement : MonoBehaviour {
        public Rigidbody2D body;
        public new SpriteRenderer renderer;
        public float speed = 1f;
        public MovementAnimator animator;

        public IDirection Direction { get; set; }


        public void FixedUpdate() {
            body.velocity = Direction.Value * speed;

            animator.Play(Direction.Value != Vector2.zero);

            if (Direction.Value != Vector2.zero)
                renderer.flipX = Direction.Value.x > 0;
        }
    }
}