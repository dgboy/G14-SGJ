using UnityEngine;

namespace Core.Game.Common.Systems {
    public class Movement : MonoBehaviour {
        public Rigidbody2D body;
        public new SpriteRenderer renderer;
        public float speed = 1f;

        private static Vector2 Input => new(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));


        public void FixedUpdate() {
            body.velocity = Input * speed;
            
            if (Input != Vector2.zero)
                renderer.flipX = Input.x > 0;
        }
    }
}