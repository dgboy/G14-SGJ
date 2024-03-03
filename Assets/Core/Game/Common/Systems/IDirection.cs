using UnityEngine;

namespace Core.Game.Common.Systems {
    public interface IDirection {
        Vector2 Value { get; }
    }
    
    class InputService : IDirection {
        public Vector2 Value => new(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
    }
}