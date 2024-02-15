using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Bonus.Extra {
    public class ExtraHealthActivationSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<CExtraArmor, EActivation>> _filter = default;
        private readonly EcsPoolInject<EActivation> _activations = default;
        private readonly EcsPoolInject<CHealth> _healths = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                TryAdd(_activations.Value.Get(id).by.id);
            }
        }

        private void TryAdd(int id) {
            if (!_healths.Value.Has(id))
                return;

            ref var health = ref _healths.Value.Get(id);
            health.value++;
        }
    }
}