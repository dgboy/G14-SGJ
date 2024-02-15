using Core.Common.Data;
using Core.Game.Common.Factories;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Bonus.Invincibility {
    public class InvincibilityActivationSystem : IEcsRunSystem {
        private readonly EcsFilterInject<Inc<CInvincibility, EActivation>> _filter = default;
        private readonly EcsPoolInject<EActivation> _activations = default;

        private readonly EcsCustomInject<GeneralConfig> _configs = default;
        private readonly EcsCustomInject<StatusVFXFactory<SInvincible>> _statusFactory = default;
        private BonusData Config => _configs.Value.bonus;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                _statusFactory.Value.Create(Config.invincible, _activations.Value.Get(id).by);
            }
        }
    }
}