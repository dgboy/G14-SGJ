using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Bonus.Grenade {
    public class GrenadeActivationSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<CGrenade, EActivation>> _filter = default;
        private readonly EcsPoolInject<EActivation> _activations = default;
        private readonly EcsFilterInject<Inc<CTank>> _tankFilter = default;
        private readonly EcsPoolInject<CTank> _tanks = default;
        private readonly EcsPoolInject<EDeath> _deaths = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                var activation = _activations.Value.Get(id);

                if (_tanks.Value.Has(activation.by.id))
                    DestroyAllTanksExcept(_tanks.Value.Get(activation.by.id).group);
            }
        }

        private void DestroyAllTanksExcept(string group) {
            foreach (int id in _tankFilter.Value) {
                if (_tanks.Value.Get(id).group != group)
                    _deaths.Value.Add(id);
            }
        }
    }
}