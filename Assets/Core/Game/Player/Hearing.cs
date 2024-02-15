using Core.Common;
using Core.Common.Data;
using Core.Game.Common.Behaviors;
using DG.Tweening;
using UnityEngine;

namespace Core.Game.Player {
    public class Hearing : MonoBehaviour {
        public DrawRadar radar;
        public HearingLevel[] levels;

        private RuntimeData _data;
        private Observable<int> Level { get; set; }


        public void Init(GeneralConfig config, RuntimeData data) {
            _data = data;
            Level = _data.HearingLevel;
            radar.Radius = Level.Value;

            levels[0].Initialize(config.hearing.low, 0);
            levels[1].Initialize(config.hearing.middle, 1);
            levels[2].Initialize(config.hearing.high, 2);

            // var clips = { config.hearing.low, config.hearing.middle, config.hearing.high };
            // for (int i = 0; i < levels.Length; i++) {
            //     levels[i].Initialize(clips[i], i);
            // }
        }
        private void Update() {
            if (Input.mouseScrollDelta != Vector2.zero)
                Raise(Input.mouseScrollDelta.normalized);


            for (int i = 0; i < levels.Length; i++) {
                var level = levels[i];
                level.enabled = Level.Value > i;
            }
        }


        private void Raise(Vector2 step) {
            Level.Value = (int)Mathf.Clamp(Level.Value + step.y, 0f, 3f);
            PlayVFX();
        }

        private void PlayVFX() {
            var sequence = DOTween.Sequence();
            sequence.Append(DOTween.To(() => radar.Radius, x => radar.Radius = x, Level.Value, 0.5f));
            // sequence.Insert(0, radar._lineDrawer.DOColor(Color.white, new Color3(), 0.5f));
            // sequence.AppendInterval(1f);
            // sequence.Append(DOTween.To(() => LightRadius, x => LightRadius = x, initRadius, 0.5f));
        }
    }
}