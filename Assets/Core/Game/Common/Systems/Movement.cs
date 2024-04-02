using Core.Game.Common.Input;
using UnityEngine;

namespace Core.Game.Common.Systems {
    public class Movement : MonoBehaviour {
        public Rigidbody2D body;
        public new SpriteRenderer renderer;
        public float speed = 1f;
        public MovementAnimator animator;

        public IInputService Input { get; set; }


        public void FixedUpdate() {
            body.velocity = Input.Direction * speed;

            animator.Play(Input.Direction != Vector2.zero);

            if (Input.Direction != Vector2.zero)
                renderer.flipX = Input.Direction.x > 0;
        }
    }
}