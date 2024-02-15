using Core.Common.Data;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Bonus.TimeStop {
    public class StoppingEnemySystem : IEcsRunSystem {
        private readonly EcsCustomInject<GeneralConfig> _configs = default;
        private readonly EcsFilterInject<Inc<ETimeStop, EActivation>> _filter = default;
        private readonly EcsPoolInject<EActivation> _activations = default;

        private readonly EcsPoolInject<CTank> _tanks = default;
        private readonly EcsPoolInject<SStopped> _statuses = default;
        private readonly EcsFilterInject<Inc<CTank>> _targetFilter = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                var activation = _activations.Value.Get(id);

                if (_tanks.Value.Has(activation.by.id))
                    StopAllExcept(_tanks.Value.Get(activation.by.id).group);
            }
        }

        private void StopAllExcept(string group) {
            foreach (int id in _targetFilter.Value) {
                if (_tanks.Value.Get(id).group == group || _statuses.Value.Has(id))
                    continue;

                ref var status = ref _statuses.Value.Add(id);
                status.Expired = _configs.Value.bonus.timeStopDuration;
            }
        }
    }
}