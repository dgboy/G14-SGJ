using UnityEngine;

namespace Core.Game.Common.Behaviors {
    public class Entity : MonoBehaviour {
        public int id = Empty;

        private const int Empty = -1;

        public override string ToString() => $"{name}";
    }
}