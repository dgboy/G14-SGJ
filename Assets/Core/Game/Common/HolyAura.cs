using UnityEngine;

namespace Core.Game.Common {
    [RequireComponent(typeof(Collider2D))]
    public class HolyAura : MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D other) {
            if (IsTarget(other) && other.TryGetComponent(out IBanishAble able))
                able.Banish();
        }

        private bool IsTarget(Component other) => other.CompareTag(tag);
    }
}