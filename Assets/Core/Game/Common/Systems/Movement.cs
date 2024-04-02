using Core.Common.Utils;
using Core.Game.Common.Input;
using UnityEngine;

namespace Core.Game.Common.Systems {
    public class Movement : MonoBehaviour {
        public Rigidbody2D body;
        public float speed = 1f;
        public MovementAnimator animator;

        public IInputService Input { get; set; }


        public void FixedUpdate() {
            body.velocity = Input.Direction * speed;

            animator.Play(Input.Direction != Vector2.zero);

            if (Input.Direction != Vector2.zero)
                body.transform.rotation = (Input.Direction * Vector2.left).ToRotation();
        }
    }
}