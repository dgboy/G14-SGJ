using Core.Common.Data;
using Core.Game.Hit;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Tank {
    public class ExplosionSoundSystem : IEcsRunSystem {
        private readonly EcsCustomInject<GeneralConfig> _config = default;
        private readonly EcsWorldInject _world;
        private readonly EcsFilterInject<Inc<EDeath, CExplosive>> _filter = default;
        private readonly EcsPoolInject<ESound> _sounds = default;
        private HitData Config => _config.Value.hit;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                ref var sound = ref _sounds.Value.Add(id);
                sound.value = Config.deathSound;
            }
        }
    }
}