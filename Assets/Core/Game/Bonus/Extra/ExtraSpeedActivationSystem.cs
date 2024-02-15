using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Bonus.Extra {
    public class ExtraSpeedActivationSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<CExtraSpeed, EActivation>> _filter = default;
        private readonly EcsPoolInject<EActivation> _activations = default;
        private readonly EcsPoolInject<CSpeed> _pool = default;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                TryAdd(_activations.Value.Get(id).by.id);
            }
        }

        private void TryAdd(int id) {
            if (!_pool.Value.Has(id))
                return;

            ref var item = ref _pool.Value.Get(id);
            item.value *= 2f;
        }
    }
}