using Core.Common.Data;
using Core.Game.Common.Factories;
using Core.Game.Hit;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Core.Game.Common.Systems {
    public class ExplosionEffectSystem : IEcsRunSystem {
        private readonly EcsCustomInject<GeneralConfig> _config = default;
        private readonly EcsCustomInject<VfxFactory> _vfxFactory = default;

        private readonly EcsWorldInject _world;
        private readonly EcsFilterInject<Inc<EDeath, CExplosive>> _filter = default;
        private readonly EcsPoolInject<CTransform> _transforms = default;
        private HitData Config => _config.Value.hit;


        public void Run(IEcsSystems systems) {
            foreach (int id in _filter.Value) {
                var transform = _transforms.Value.Get(id);
                _vfxFactory.Value.Create(Config.deathVfx, transform.value.position);
            }
        }
    }
}