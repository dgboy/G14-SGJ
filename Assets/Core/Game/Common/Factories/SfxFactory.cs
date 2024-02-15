using Core.Common.Data;
using Leopotam.EcsLite;
using UnityEngine;

namespace Core.Game.Common.Factories {
    public class SfxFactory {
        public SfxFactory(GeneralConfig config, EcsWorld world) {
            _config = config;
            _world = world;
            _transforms = world.GetPool<CTransform>();
            _lifespans = world.GetPool<CLifespan>();
        }

        private readonly GeneralConfig _config;
        private readonly EcsWorld _world;
        private readonly EcsPool<CTransform> _transforms;
        private readonly EcsPool<CLifespan> _lifespans;


        public void Create(AudioClip sound) {
            int id = _world.NewEntity();
            var sample = Object.Instantiate(_config.sfx);
            sample.name = $"sfx-{id} <{sound.name}>";
            sample.Play(sound);

            ref var transform = ref _transforms.Add(id);
            transform.value = sample.transform;

            ref var lifespan = ref _lifespans.Add(id);
            lifespan.duration = sample.Duration;
        }
    }
}