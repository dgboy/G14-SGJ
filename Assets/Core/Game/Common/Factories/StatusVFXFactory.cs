using Core.Game.Bonus;
using Core.Game.Common.Behaviors;
using Leopotam.EcsLite;
using UnityEngine;

namespace Core.Game.Common.Factories {
    public class StatusVFXFactory<TStatus> where TStatus : struct, IStatus {
        public StatusVFXFactory(EcsWorld world) {
            _world = world;
            _statuses = world.GetPool<TStatus>();
            _transforms = world.GetPool<CTransform>();
            _lifespans = world.GetPool<CLifespan>();
        }

        private readonly EcsWorld _world;
        private readonly EcsPool<TStatus> _statuses;
        private readonly EcsPool<CTransform> _transforms;
        private readonly EcsPool<CLifespan> _lifespans;


        public void Create(StatusData data, Entity owner) {
            if (_statuses.Has(owner.id))
                return;

            ref var status = ref _statuses.Add(owner.id);
            status.Expired = data.duration;

            var sample = Object.Instantiate(data.prefab, owner.transform);
            sample.id = _world.NewEntity();
            sample.name = $"vfx-{sample.id} <{data.prefab.name}>";

            ref var transform = ref _transforms.Add(sample.id);
            transform.value = sample.transform;

            ref var lifespan = ref _lifespans.Add(sample.id);
            lifespan.duration = data.duration;
        }
    }
}