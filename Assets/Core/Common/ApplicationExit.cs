using UnityEngine;

namespace Core.Common {
    public class ApplicationExit : MonoBehaviour {
        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }
}