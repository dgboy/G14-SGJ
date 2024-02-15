using Core.Game.Common.Behaviors;
using Leopotam.EcsLite;
using UnityEngine;

namespace Core.Game.Common.Factories {
    public class VfxFactory {
        public VfxFactory(EcsWorld world) {
            _world = world;
            _transforms = world.GetPool<CTransform>();
            _lifespans = world.GetPool<CLifespan>();
        }

        private readonly EcsWorld _world;
        private readonly EcsPool<CTransform> _transforms;
        private readonly EcsPool<CLifespan> _lifespans;


        public VisualFX Create(VisualFX vfx, Vector2 position) {
            int id = _world.NewEntity();
            var sample = Object.Instantiate(vfx, position, Quaternion.identity);
            sample.name = $"vfx-{id} <{vfx.name}>";
            sample.Play();

            ref var transform = ref _transforms.Add(id);
            transform.value = sample.transform;

            ref var lifespan = ref _lifespans.Add(id);
            lifespan.duration = sample.Duration;
            return sample;
        }
    }
}