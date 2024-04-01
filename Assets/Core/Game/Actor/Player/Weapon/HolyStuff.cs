using Core.Game.Common;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Core.Game.Actor.Player.Weapon {
    public class HolyStuff : MonoBehaviour {
        public new Light2D light;
        public new AudioSource audio;
        public new CircleCollider2D collider;

        public float fullRadius = 2f;
        public float initRadius = 0.2f;
        private Cooldown _cooldown;
        private float LightRadius {
            get => light.pointLightOuterRadius;
            set {
                light.pointLightOuterRadius = value;
                collider.radius = value;
            }
        }

        private void Start() {
            LightRadius = initRadius;
            _cooldown = new Cooldown(this);
        }
        private void Update() {
            if (Input.GetMouseButton(0) && _cooldown.IsExpired)
                Use();
        }

        private void Use() {
            audio.Play();
            PlayVFX();
            _cooldown.Start(2f);
        }
        private void PlayVFX() {
            var sequence = DOTween.Sequence();
            sequence.Append(DOTween.To(() => LightRadius, x => LightRadius = x, fullRadius, 0.5f));
            sequence.AppendInterval(1f);
            sequence.Append(DOTween.To(() => LightRadius, x => LightRadius = x, initRadius, 0.5f));
        }
    }
}