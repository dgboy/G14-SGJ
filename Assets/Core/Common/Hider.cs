using UnityEngine;

namespace Core.Common {
    public class Hider : MonoBehaviour {
        private void Start() => gameObject.SetActive(false);
    }
}