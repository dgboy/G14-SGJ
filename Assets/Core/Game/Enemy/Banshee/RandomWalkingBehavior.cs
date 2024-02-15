using UnityEngine;

namespace Core.Game.Enemy.Banshee {
    public class RandomWalkingBehavior : MonoBehaviour {
        public float width = 10f;
        public float depth = 10f;
        public Vector3 origin;

        private Vector3 Target { get; set; }


        private void Start() {
            origin = Target = transform.position;
        }
        private void Update() {
            if (Vector2.Distance(transform.position, Target) > 1f) {
                Move();
            } else {
                Target = GetRandomPoint();
            }
        }

        private Vector3 GetRandomPoint() {
            var randomPoint = new Vector3((Random.value - 0.5f) * width, (Random.value - 0.5f) * depth);
            return origin + randomPoint;
        }

        private void Move() {
            float step = Time.deltaTime * 5f;
            transform.position = Vector2.MoveTowards(transform.position, Target, step);
        }

        private void OnDrawGizmos() {
            if (origin == Vector3.zero)
                return;

            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(origin, new Vector3(width, depth));
        }
    }
}