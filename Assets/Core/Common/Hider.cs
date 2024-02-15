using UnityEngine;

namespace Core {
    public class Hider : MonoBehaviour {
        private void Start() => gameObject.SetActive(false);
    }
}