using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Map.Mine {
    public class MineActivationSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<CMine, EActivation>> _filter = default;
        private readonly EcsPoolInject<EHit> _hits = default;
        private readonly EcsPoolInject<EActivation> _activations = default;
        // private readonly EcsPoolInject<EDeath> _deaths = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                // _deaths.Value.Add(id);
                TryTakeDamage(_activations.Value.Get(id));
            }
        }

        private void TryTakeDamage(EActivation activation) {
            ref var hit = ref _hits.Value.Add(activation.by.id);
            hit.damage = 10;
            hit.position = activation.by.transform.position;
            // Debug.Log($"<{activation.by.name}> has {hit.value} health units left.");
        }
    }
}