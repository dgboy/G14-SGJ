using UnityEngine;

namespace Core.Game.Common.Behaviors {
    public class VisualFX : MonoBehaviour {
        private const string StateName = "play";

        public Animator animator;

        public float Duration => animator.GetCurrentAnimatorStateInfo(0).length;

        public void Play() => animator.Play(StateName);
    }
}