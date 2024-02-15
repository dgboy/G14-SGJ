using Core.Common.Data;
using UnityEngine;
using VContainer;

namespace Core.Game.Common {
    public class MusicService {
        [Inject] private LevelContext Context { get; set; }

        private AudioSource Source => Context.musicSource;


        public void Play(AudioClip clip, bool loop = false) {
            Source.Stop();
            Source.clip = clip;
            Source.loop = loop;
            Source.Play();
        }
    }
}