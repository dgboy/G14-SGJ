using Core.Game.Common.Systems;
using UnityEngine;

namespace Core.Game.Actor.Enemy.Banshee {
    public class RandomWalkingBehavior : MonoBehaviour {
        public MovementAnimator animator;
        public float width = 10f;
        public float depth = 10f;
        public Vector3 origin;
        public float speed = 5f;

        public Vector3 Target { get; set; }


        private void Start() {
            origin = Target = transform.position;
        }
        private void Update() {
            bool farAway = Vector2.Distance(transform.position, Target) > 1f;
            animator.Play(farAway);

            if (farAway)
                Move();
            else
                Target = GetRandomPoint();
        }

        private Vector3 GetRandomPoint() {
            var randomPoint = new Vector3((Random.value - 0.5f) * width, (Random.value - 0.5f) * depth);
            return origin + randomPoint;
        }

        private void Move() {
            transform.position = Vector2.MoveTowards(transform.position, Target, speed * Time.deltaTime);
        }

        private void OnDrawGizmos() {
            if (origin == Vector3.zero)
                return;

            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(origin, new Vector3(width, depth));
        }
    }
}