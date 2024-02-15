using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Common.Systems {
    public class LifespanSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<CLifespan>, Exc<EDeath>> _filter = default;
        private readonly EcsPoolInject<CLifespan> _lifespans = default;
        private readonly EcsPoolInject<EDeath> _deaths = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                ref var lifespan = ref _lifespans.Value.Get(id);
                lifespan.duration -= Time.deltaTime;

                if (lifespan.duration > 0)
                    continue;

                _deaths.Value.Add(id);
                _lifespans.Value.Del(id);
                // Debug.Log("--- LIFE-END ---");
            }
        }
    }
}