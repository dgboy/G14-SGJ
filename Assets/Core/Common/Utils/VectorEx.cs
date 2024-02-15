using UnityEngine;

namespace Core.Common.Utils {
    public static class VectorEx {
        public static Vector2 Abs(this Vector2 v) => new(Mathf.Abs(v.x), Mathf.Abs(v.y));
        public static Vector2 Swap(this Vector2 v) => new(v.y, v.x);
        public static Vector2 Sign(this Vector2 v) =>
            new(v.x == 0 ? v.x : Mathf.Sign(v.x), v.y == 0 ? v.y : Mathf.Sign(v.y));

        public static Quaternion ToRotation(this Vector2 direction) {
            float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            return Quaternion.Euler(0f, rotation, 0);
        }

        public static Vector2 ToDirection(this Quaternion quaternion) => quaternion.eulerAngles;
    }
}