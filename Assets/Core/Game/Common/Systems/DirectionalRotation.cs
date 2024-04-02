using Core.Game.Common.Input;
using UnityEngine;

namespace Core.Game.Common.Systems {
    public class DirectionalRotation : MonoBehaviour {
        public IInputService Input { get; set; }

        private Vector3 _point;
        // public new SpriteRenderer renderer;

        private void Start() {
            _point = transform.localPosition;
            Rotate();
        }

        public void FixedUpdate() {
            if (Input.Direction != Vector2.zero)
                Rotate();
        }

        private void Rotate() {
            transform.localPosition = new Vector3(Input.Direction.x <= 0f ? _point.x : -_point.x, _point.y);
            // if (Input.Direction != Vector2.zero)
            //     renderer.flipX = Input.Direction.x > 0;
        }
    }
}