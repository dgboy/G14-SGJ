using Core.Common.Data;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Core.Game.Bonus {
    public class BonusActivationSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<CBonus, CTrigger>> _filter = default;
        private readonly EcsPoolInject<CTrigger> _triggers = default;
        private readonly EcsPoolInject<EActivation> _activations = default;
        private readonly EcsPoolInject<ESound> _sounds = default;

        private readonly EcsCustomInject<GeneralConfig> _configs = default;

        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                var trigger = _triggers.Value.Get(id);

                if (trigger.value.Targets.Count == 0)
                    continue;

                ref var activation = ref _activations.Value.Add(id);
                activation.by = trigger.value.Targets[0];
                Debug.Log($"<{activation.by.name}> picked up a <{trigger.value.name}> bonus!");

                if (_sounds.Value.Has(id))
                    _sounds.Value.Del(id);

                ref var sound = ref _sounds.Value.Add(id);
                sound.value = _configs.Value.bonus.activationSound;
            }
        }
    }
}