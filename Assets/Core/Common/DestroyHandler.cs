using UnityEngine;

namespace Core.Common {
    public class DestroyHandler : MonoBehaviour {
        public SpriteRenderer spriteRenderer;

        private void OnDestroy() => spriteRenderer.enabled = false;
    }
}