using System.Collections;
using UnityEngine;

namespace Core.Game {
    public class Cooldown {
        private readonly MonoBehaviour _runner;
        private Coroutine _current;
        private float _time;
        public bool IsExpired => _time <= 0;

        public Cooldown(MonoBehaviour runner) => _runner = runner;


        public void Start(float time) {
            Stop();

            _time = time;
            _current = _runner.StartCoroutine(Refresh());
        }

        private IEnumerator Refresh() {
            while (!IsExpired) {
                yield return null;
                _time -= Time.deltaTime;
            }

            Stop();
        }

        private void Stop() {
            _time = 0;

            if (_current == null) return;

            _runner.StopCoroutine(_current);
            _current = null;
        }
    }
}