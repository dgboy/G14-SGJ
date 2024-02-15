using UnityEngine;

namespace Core.Game.Common.Behaviors {
    public class SoundFX : MonoBehaviour {
        public AudioSource source;
        public float Duration => source.clip.length;

        public void Play(AudioClip sound) {
            source.clip = sound;
            source.Play();
        }
    }
}