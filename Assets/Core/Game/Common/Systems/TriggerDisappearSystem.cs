using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Common.Systems {
    public class TriggerDisappearSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<CTrigger>> _filter = default;
        private readonly EcsPoolInject<CTrigger> _triggers = default;
        private readonly EcsPoolInject<EDeath> _deaths = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                var trigger = _triggers.Value.Get(id);
                if (trigger.value.Targets.Count > 0)
                    _deaths.Value.Add(id);
            }
        }
    }
}