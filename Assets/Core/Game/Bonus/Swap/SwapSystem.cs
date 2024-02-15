using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Bonus.Swap {
    public class SwapSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<CSwap, EActivation>> _filter = default;
        private readonly EcsPoolInject<EActivation> _activations = default;
        private readonly EcsPoolInject<CTransform> _transforms = default;
        private readonly EcsFilterInject<Inc<CTank, CTransform>> _targetFilter = default;

        
        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                var activation = _activations.Value.Get(id);

                if (!_transforms.Value.Has(activation.by.id))
                    continue;

                TrySwap(activation.by.id);
            }
        }

        private void TrySwap(int byID) {
            int oppositeID = -1;

            foreach (int id in _targetFilter.Value) {
                if (id != byID)
                    oppositeID = id;
            }

            if (oppositeID == -1)
                return;

            ref var user = ref _transforms.Value.Get(byID);
            ref var opponent = ref _transforms.Value.Get(oppositeID);
            (user.value.position, opponent.value.position) = (opponent.value.position, user.value.position);
        }
    }
}