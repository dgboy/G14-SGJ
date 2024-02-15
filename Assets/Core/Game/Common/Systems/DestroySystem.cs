using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Common.Systems {
    public class DestroySystem : IEcsRunSystem {
        private readonly EcsWorldInject _world = default;
        private readonly EcsFilterInject<Inc<EDeath, CTransform>> _filter = default;
        private readonly EcsPoolInject<EDeath> _deaths = default;
        private readonly EcsPoolInject<CTransform> _transforms = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                var target = _transforms.Value.Get(id).value.gameObject;

                _deaths.Value.Del(id);
                _world.Value.DelEntity(id);
                Object.Destroy(target);
                // Debug.Log("=== DEATH ===");
            }
        }
    }
}