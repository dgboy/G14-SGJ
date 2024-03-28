using System;
using Core.Game.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Game.Player {
    public class HearingLevel : MonoBehaviour {
        public AudioSource source;
        public int index;
        private AudioClip[] _clips;

        private float Delay { get; set; }
        private Cooldown _cooldown;

        
        public void Initialize(AudioClip[] clips, int id) {
            _clips = clips;
            Delay = 3f * (id + 1);
            _cooldown = new Cooldown(this);
            enabled = false;//_clips is { Length: > 0 };
        }
        private void Update() {
            if (!_cooldown.IsExpired)
                return;

            var clip = _clips[index % _clips.Length];
            source.PlayOneShot(clip);
            Debug.Log(clip.name);
            
            index++;
            _cooldown.Start(clip.length + Random.Range(Delay, Delay + 5f));
        }
    }
}