using Core.Common.Data;
using Core.Game.Common;
using DG.Tweening;
using UnityEngine;

namespace Core.Game.Actor.Enemy.Banshee {
    public class Banshee : MonoBehaviour, IBanishAble {
        public new SpriteRenderer renderer;
        public new AudioSource audio;
        private Sequence _currentAnimation;
        private RuntimeData _data;

        private const float BanishDuration = 0.5f;
        private const float Punch = 3f;
        public Transform Target { get; set; }
        private float Distance => Vector2.Distance(transform.position, Target.position);
        private Vector2 Direction => (transform.position - Target.position).normalized;

        public void Initialize(RuntimeData data) {
            _data = data;
            Target = _data.Player;
        }
        private void Update() {
            if (!Target)
                return;

            if (Distance > _data.HearingLevel.Value * 2f) {
                Move();
            } else {
                Scream();
                Stay();
            }
        }

        private void Move() {
            float step = Time.deltaTime * 5f;
            transform.position = Vector2.MoveTowards(transform.position, Target.position, step);
            // var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            // transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
        }
        private void Scream() {
            audio.Play();
            PlayVFX();
            _data.FearLevel.Value -= 0.2f;
        }
        private void PlayVFX() {
            _currentAnimation = DOTween.Sequence();
            // sequence.AppendInterval(2.7f); //audio.clip.length
            _currentAnimation.Append(transform.DOPunchScale(Vector2.one * 2f, 2.7f));
            _currentAnimation.AppendCallback(Banish);
        }

        public void Banish() {
            if (_currentAnimation is { active: true })
                _currentAnimation.Kill();

            _currentAnimation = DOTween.Sequence();
            _currentAnimation.Append(transform.DOPunchScale(-Vector2.one * Punch, BanishDuration));
            // _currentAnimation.Insert(0, transform.DOPunchPosition(-Direction * Punch, BanishDuration));
            _currentAnimation.Insert(0, renderer.DOFade(0f, BanishDuration));
            _currentAnimation.AppendCallback(() => Destroy(gameObject));
        }
        private void Stay() => enabled = false;
    }
}