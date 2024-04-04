using UnityEngine;

namespace Core.Game.Common.Behaviors {
    public class MouseTrail : MonoBehaviour {
        [field: SerializeField] public TrailRenderer Renderer { get; set; }
        public Camera Main => Camera.main;


        private void Update() {
            bool active = UnityEngine.Input.GetMouseButton(0);
            // Renderer.emitting = active;

            if (!active)
                return;

            var position = UnityEngine.Input.mousePosition;
            transform.position = Main.ScreenToWorldPoint(new Vector3(position.x, position.y, -Main.transform.position.z));
        }
    }
}