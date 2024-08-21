using Core.Game.Common.Systems;
using UnityEngine;

namespace Core.Game.Actor.Enemy.Banshee {
    public class FollowingBehavior : MonoBehaviour {
        public MovementAnimator animator;
        public float speed = 5f;

        public Transform Target { get; set; }


        private void Update() {
            bool farAway = Vector2.Distance(transform.position, Target.position) > 1f;
            animator.Play(farAway);

            if (farAway)
                Move();
        }

        private void Move() {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
        }

        // private void OnDrawGizmos() {
        //     if (origin == Vector3.zero)
        //         return;
        //
        //     Gizmos.color = Color.cyan;
        //     Gizmos.DrawWireCube(origin, new Vector3(width, depth));
        // }
    }
}