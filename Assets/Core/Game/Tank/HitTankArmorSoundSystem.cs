using Core.Common.Data;
using Core.Game.Hit;
using Core.Game.Map;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Tank {
    public class HitTankArmorSoundSystem : IEcsRunSystem {
        private readonly EcsCustomInject<GeneralConfig> _config = default;

        private readonly EcsWorldInject _world;
        private readonly EcsFilterInject<Inc<EHit, CHealth>, Exc<EDeath, CBlock>> _filter = default;
        private readonly EcsPoolInject<ESound> _sounds = default;
        private readonly EcsPoolInject<CHealth> _healths = default;
        private HitData Config => _config.Value.hit;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                var health = _healths.Value.Get(id);
                ref var sound = ref _sounds.Value.Add(id);

                if (health.value > 0)
                    sound.value = Config.armorSound;
            }
        }
    }
}