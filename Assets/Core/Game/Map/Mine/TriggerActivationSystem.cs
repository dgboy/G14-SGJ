using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Map.Mine {
    public class TriggerActivationSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<CMine, CTrigger>> _filter = default;
        private readonly EcsPoolInject<CTrigger> _triggers = default;
        private readonly EcsPoolInject<EActivation> _activations = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                var trigger = _triggers.Value.Get(id);

                if (trigger.value.Targets.Count == 0)
                    continue;

                ref var activation = ref _activations.Value.Add(id);
                activation.by = trigger.value.Targets[0];
                Debug.Log($"<{activation.by.name}> was blown up by <{trigger.value.name}>");
            }
        }
    }
}