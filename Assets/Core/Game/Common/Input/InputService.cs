using UnityEngine;

namespace Core.Game.Common.Input {
    class InputService : IInputService {
        public Vector2 Direction => new(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
    }
}